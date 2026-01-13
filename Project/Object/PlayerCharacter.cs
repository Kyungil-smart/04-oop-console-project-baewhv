using System.Text;

namespace Project;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> _health = new ObservableProperty<int>(5);

    private Shape[] Faces;
    
    public Map CurrentMap { get; set; }
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

    }

    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
    }

    public void Move(Direction dir)
    {
        if (CurrentMap == null || !IsActiveControl) return;
        Vector direction = Vector.Zero;
        switch (dir)
        {
            case Direction.Up:
                direction = Vector.Up;
                break;
            case Direction.Down:
                direction = Vector.Down;
                break;
            case Direction.Left:
                direction = Vector.Left;
                break;
            case Direction.Right:
                direction = Vector.Right;
                break;
        }
        shape[0] = Faces[(int)dir];
        Vector nextPos = Position + direction;
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