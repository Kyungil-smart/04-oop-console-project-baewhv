namespace Project;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> _health = new ObservableProperty<int>(5);
    
    //public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public PlayerCharacter() => Init();
    private bool IsActiveControl;
    public void Init()
    {
        SetSymbol("⭐".ToCharArray());
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
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
        }
        if (InputManager.GetKey(ConsoleKey.LeftArrow))
            Move(Vector.Left);
        if (InputManager.GetKey(ConsoleKey.RightArrow))
            Move(Vector.Right);
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