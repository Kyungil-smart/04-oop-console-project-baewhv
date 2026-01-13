using System.Text;

namespace Project;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> _health = new ObservableProperty<int>(5);
    private Shape[] Faces;
    private Direction _dir = Direction.Down;
    public bool HasWeapon { get; set; }

    public Map CurrentMap { get; set; }

    //UI
    public DialogFrame DialogFrame { get; set; }
    public SkillFrame SkillFrame { get; set; }
    public Inventory _inventory { get; set; }
    public ScreenFrame ScreenFrame { get; set; }

    public PlayerCharacter() => Init();
    private bool IsActiveControl;

    public void Init()
    {
        Faces = new Shape[4];
        Faces[0] = new Shape()
            { Position = Vector.Zero, Symbol = new StringBuilder("\u2570\u256f"), Type = CollisionType.None };
        Faces[1] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("``"), Type = CollisionType.None };
        Faces[2] = new Shape()
            { Position = Vector.Zero, Symbol = new StringBuilder("`\u256f"), Type = CollisionType.None };
        Faces[3] = new Shape()
            { Position = Vector.Zero, Symbol = new StringBuilder("\u2570`"), Type = CollisionType.None };

        shape = new Shape[2];
        shape[0] = Faces[1];
        shape[1] = new Shape()
            { Position = new Vector(0, -1), Symbol = new StringBuilder("\u25e2\u25e3"), Color = ConsoleColor.Green };

        _inventory = new Inventory(this);
        IsActiveControl = true;
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Direction.Up);
            _inventory.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Direction.Down);
            _inventory.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow))
            Move(Direction.Left);
        if (InputManager.GetKey(ConsoleKey.RightArrow))
            Move(Direction.Right);
        if (InputManager.GetKey(ConsoleKey.I))
        {
            HandleControl();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }

        if (InputManager.GetKey(ConsoleKey.Subtract))
        {
            Heal(-1);
        }

        if (InputManager.GetKey(ConsoleKey.Add))
        {
            Heal(+1);
        }

        if (InputManager.GetKey(ConsoleKey.F))
        {
            Interact();
        }

        if (InputManager.GetKey(ConsoleKey.Spacebar))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (!HasWeapon) return;

        switch (_dir)
        {
            case Direction.Down:
                Console.SetCursorPosition(ScreenFrame.GetSize.X-1, ScreenFrame.GetSize.Y/2+2);
                "\u2570----\u256f".Print(ConsoleColor.Red);
                break;
            case Direction.Up:
                Console.SetCursorPosition(ScreenFrame.GetSize.X-1, ScreenFrame.GetSize.Y/2);
                "\u256d----\u256e".Print(ConsoleColor.Red);
                break;
            case Direction.Left:
                Console.SetCursorPosition(ScreenFrame.GetSize.X-1, ScreenFrame.GetSize.Y/2+2);
                " \u239d".Print(ConsoleColor.Red);
                Console.SetCursorPosition(ScreenFrame.GetSize.X-1, ScreenFrame.GetSize.Y/2+1);
                " \u239c".Print(ConsoleColor.Red);
                Console.SetCursorPosition(ScreenFrame.GetSize.X-1, ScreenFrame.GetSize.Y/2+0);
                " \u239b".Print(ConsoleColor.Red);
                break;
            case Direction.Right:
                Console.SetCursorPosition(ScreenFrame.GetSize.X+3, ScreenFrame.GetSize.Y/2+2);
                "\u23a0".Print(ConsoleColor.Red);
                Console.SetCursorPosition(ScreenFrame.GetSize.X+3, ScreenFrame.GetSize.Y/2+1);
                "\u239f".Print(ConsoleColor.Red);
                Console.SetCursorPosition(ScreenFrame.GetSize.X+3, ScreenFrame.GetSize.Y/2+0);
                "\u239e".Print(ConsoleColor.Red);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        Thread.Sleep(100);
        


        KeyValuePair<int, GameObject> target = CurrentMap.CheckObject(Position + Vector.GetDirectVector(_dir));
        if (target.Value is IInteractable t)
        {
            t.Interact(this);
        }
    }

    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
    }

    public void Interact()
    {
        KeyValuePair<int, GameObject> target = CurrentMap.CheckObject(Position + Vector.GetDirectVector(_dir));
        if (target.Value is IInteractable t)
        {
            t.Interact(this);
            if (target.Value is Item)
                CurrentMap.RemoveObject(target.Key);
        }
    }

    public void Move(Direction dir)
    {
        if (CurrentMap == null || !IsActiveControl) return;
        _dir = dir;

        shape[0] = Faces[(int)dir];
        Vector nextPos = Position + Vector.GetDirectVector(_dir);
        Vector current = Position;
        if (CurrentMap.CheckMove(nextPos, this))
        {
            Position = nextPos;

            Debug.LogWarning($"플레이어 이동 : ({current.X},{current.Y}) -> ({nextPos.X},{nextPos.Y})");
        }
    }

    public void Render()
    {
        _inventory.Render();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    private string _healthGauge;

    public void SetDamage(int value)
    {
        _health.Value -= value;
    }

    public void Heal(int value)
    {
        _health.Value += value;
    }
}