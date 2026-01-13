using System.Text;

namespace Project;

public abstract class Map //배치할 월드 데이터
{
    protected int _width;
    protected int _height;

    private StringBuilder floor = new StringBuilder("  ");
    private StringBuilder Outside = new StringBuilder("\u2591\u2591");

    public int GetMinWidth() => -((_width - 1) / 2);
    public int GetMaxWidth() => (_width - 1) / 2;
    public int GetMinHeight() => -((_height - 1) / 2);
    public int GetMaxHeight() => (_height - 1) / 2;

    public Vector StartPos { get; protected set; }
    
    private SortedDictionary<int, GameObject> _objects = new SortedDictionary<int, GameObject>();

    protected Map(Vector startPos, int width = 1, int height = 1)
    {
        _width = width * 2 + 1;
        _height = height * 2 + 1;
        StartPos = startPos;
    }

    protected Map(Vector startPos)
    {
        StartPos = startPos;
    }

    public void SetObject(GameObject obj)
    {
        _objects[obj.GetPriority(_width, _height)] = obj;
    }

    public void SetScreen(ScreenFrame frame, PlayerCharacter pc)
    {
        int LeftMax = pc.Position.X - frame.GetSize.X / 2;
        int TopMax = pc.Position.Y + frame.GetSize.Y / 2;
        for (int y = 0; y < frame.GetSize.Y; y++)
        {
            for (int x = 0; x < frame.GetSize.X; x++)
            {
                if (CheckRange(LeftMax + x, TopMax - y))
                {
                    frame.SetData((x, y), floor);
                }
                else
                {
                    frame.SetData((x, y), Outside, ConsoleColor.DarkGray);
                }
            }
        }

        foreach (KeyValuePair<int, GameObject> obj in _objects)
        {
            Vector temp = obj.Value.Position;
            if (temp.X >= LeftMax && temp.Y <= TopMax && temp.X <= LeftMax + frame.GetSize.X * 2 &&
                temp.Y >= TopMax - frame.GetSize.Y * 2)
            {
                Vector pcToObj = obj.Value.Position - pc.Position;
                pcToObj.Y *= -1;
                temp = frame.GetSize / 2 + pcToObj;

                for (int i = 0; i < obj.Value.shape.Length; i++)
                {
                    frame.SetData(temp + obj.Value.shape[i].Position, obj.Value.shape[i].Symbol,
                        obj.Value.shape[i].Color);
                }
            }
        }

        for (int i = 0; i < pc.shape.Length; i++)
        {
            frame.SetData((frame.GetSize / 2) + pc.shape[i].Position, pc.shape[i].Symbol, pc.shape[i].Color);
        }
    }

    public bool CheckRange(int x, int y)
    {
        return x >= GetMinWidth() &&
               x <= GetMaxWidth() &&
               y >= GetMinHeight() &&
               y <= GetMaxHeight();
    }

    public bool CheckMove(Vector pos, PlayerCharacter pc)
    {
        if (!CheckRange(pos.X, pos.Y)) return false;
        int temp = -1;
        foreach (KeyValuePair<int, GameObject> obj in _objects)
        {
            if (temp != -1) break;
            foreach (Shape sp in obj.Value.shape)
            {
                if ((obj.Value.Position+sp.Position).Compare(pos))
                {
                    if (sp.Type == CollisionType.Obstacle)
                        return false;
                    if (obj.Value is IInteractable)
                    {
                        (obj.Value as IInteractable)?.Interact(pc);
                        temp = obj.Key;
                        break;
                    }
                    temp = -2;
                    break;
                }   
            }
        }

        if (temp > 0)
        {
            if (_objects.Remove(temp))
                return true;
        }
        return true;
    }
}