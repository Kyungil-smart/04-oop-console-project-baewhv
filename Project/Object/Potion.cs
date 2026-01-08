namespace Project;

public class Potion : Item, IInteractable
{
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