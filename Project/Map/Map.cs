namespace Project;

public abstract class Map //배치할 월드 데이터
{
    protected int _width;
    protected int _height;

    public int GetMinWidth() => -((_width - 1) / 2);
    public int GetMaxWidth() => (_width - 1) / 2;
    public int GetMinHeight() => -((_height - 1) / 2);
    public int GetMaxHeight() => (_height - 1) / 2;

    public Vector StartPos { get; protected set; }
    protected SortedDictionary<int, GameObject> Objects = new SortedDictionary<int, GameObject>();

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
        Objects[obj.GetPriority(_width, _height)] = obj;
    }

    public void SetScreen(ScreenFrame frame, PlayerCharacter pc)
    {
        int LeftMax = pc.Position.X - frame.GetSize.X / 2;
        int TopMax = pc.Position.Y + frame.GetSize.Y / 2;
        for (int y = 0; y < frame.GetSize.Y; y++)
        {
            for (int x = 0; x < frame.GetSize.X; x++)
            {
                // -3 -2 -1 0 1 2 3

                if (CheckRange(LeftMax + x, TopMax - y))
                {
                    frame.SetData((x, y), "  ".ToCharArray());
                }
                else 
                {
                    frame.SetData((x, y), "\u2588\u2588".ToCharArray());
                }
            }
        }
        
    }

    public bool CheckRange(int x, int y)
    {
        return x >= GetMinWidth() &&
               x <= GetMaxWidth() &&
               y >= GetMinHeight() &&
               y <= GetMaxHeight();
    }
}