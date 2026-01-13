namespace Project;

public class Inventory
{
    private List<Item> _items = new List<Item>();
    public bool IsActive { get; set; }
    public ItemList _itemMenu { get; set; }
    private PlayerCharacter _owner;

    public Inventory(PlayerCharacter owner)
    {
        _owner = owner;
    }

    public void Add(Item item)
    {
        if (_items.Count >= 10) return;
        _items.Add(item);
        _itemMenu.Add(item.Name, item.Use);
        item.Inventory = this;
        item.Owner = _owner;
    }

    public void Remove(Item item)
    {
        //if (index < 0 || _items.Count <= index) return;
        _items.Remove(item);
        _itemMenu.Remove();
    }

    public void Render()
    {
        _itemMenu.Render(IsActive);
    }

    public void Select()
    {
        if (!IsActive) return;
        _itemMenu.Select();
    }
    public void SelectUp()
    {
        if (!IsActive) return;
        _itemMenu.SelectUp();
    }
    public void SelectDown()
    {
        if (!IsActive) return;
        _itemMenu.SelectDown();
    }
}