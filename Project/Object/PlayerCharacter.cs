namespace Project;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> _health = new ObservableProperty<int>(5);
    
    public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public PlayerCharacter() => Init();
    private bool IsActiveControl;
    public void Init()
    {
        Symbol = 'P';
        _inventory = new Inventory(this);
        _inventory.Add(new Potion() {Name = "Potion 1"});
        _inventory.Add(new Potion() {Name = "Potion 2"});
        _inventory.Add(new Potion() {Name = "Potion 3"});
        _inventory.Add(new Potion() {Name = "Potion 4"});
        _health.AddListener(SetHealthGauge);
        IsActiveControl = true;
        _healthGauge = "■■■■■";
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
            //_inventory.Add(new Potion("포션"));
            //_inventory.Select();
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
        if (Field == null || !IsActiveControl) return;
        
        Vector nextPos = Position + direction;
        Vector current = Position;

        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
            }
        }
        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        Position = nextPos;
        
        Debug.LogWarning($"플레이어 이동 : ({current.X},{current.Y}) -> ({nextPos.X},{nextPos.Y})");
    }

    public void Render()
    {
        _inventory.Render();
        DrawHealthGauge();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    private string _healthGauge;

    public void DrawHealthGauge()
    {
        Console.SetCursorPosition(Position.X - 2, Position.Y-1);
        _healthGauge.Print(ConsoleColor.Red);
    }

    public void SetHealthGauge(int health)
    {
        switch (health)
        {
            case 5:
                _healthGauge = "■■■■■";
                break;
            case 4:
                _healthGauge = "■■■■□";
                break;
            case 3:
                _healthGauge = "■■■□□";
                break;
            case 2:
                _healthGauge = "■■□□□";
                break;
            case 1:
                _healthGauge = "■□□□□";
                break;
        } 
    }

    public void Heal(int value)
    {
        _health.Value += value;
    }
}