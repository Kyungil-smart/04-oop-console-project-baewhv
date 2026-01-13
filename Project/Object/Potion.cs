using System.Text;

namespace Project;

public class Potion : Item, IInteractable
{
    public Potion()
    {
        shape = new Shape[1] ;
        shape[0] = new Shape() { Position = Vector.Zero, Symbol = new StringBuilder("\u2365"), Type = CollisionType.None };
    }
    
    public override void Use()
    {
        Inventory.Remove(this);
        Inventory = null;
        Owner.Heal(1);
        Owner = null;

    }
    public void Interact(PlayerCharacter player)
    {
        player.AddItem(this);
    }
}