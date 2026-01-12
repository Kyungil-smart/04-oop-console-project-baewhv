using System.Text;

namespace Project;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> _health = new ObservableProperty<int>(5);

    private Shape[] Faces;
    
    //public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public PlayerCharacter() => Init();
    private bool IsActiveControl;
    public void Init()
    {
        Faces = new Shape[4];
        Faces[0] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("\u2570\u256f"), Type = CollisionType.None };
        Faces[1] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("``"), Type = CollisionType.None };
        Faces[2] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("`\u256f"), Type = CollisionType.None };
        Faces[3] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("\u2570`"), Type = CollisionType.None };
        
        shape = new Shape[2];
        shape[0] = Faces[1];
        shape[1] = new Shape() { Position = new Vector(0,-1), Symbol = new StringBuilder("\u25e2\u25e3"), Color = ConsoleColor.Green};
        
        _inventory = new Inventory(this);
        _inventory.Add(new Potion() {Name = "Potion 1"});
        _inventory.Add(new Potion() {Name = "Potion 2"});
        _inventory.Add(new Potion() {Name = "Potion 3"});
        _inventory.Add(new Potion() {Name = "Potion 4"});
        IsActiveControl = true;
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Vector.Up);
            _inventory.SelectUp();
            shape[0] = Faces[0];
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
            shape[0] = Faces[1];
        }
        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Move(Vector.Left);
            shape[0] = Faces[2];
        }
        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Move(Vector.Right);
            shape[0] = Faces[3];
        }
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

    }

    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
    }

    public void Move(Vector direction)
    {
        if (!IsActiveControl) return;
        Vector nextPos = Position + direction;
        Vector current = Position;
        Position = nextPos;
        
        Debug.LogWarning($"플레이어 이동 : ({current.X},{current.Y}) -> ({nextPos.X},{nextPos.Y})");
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