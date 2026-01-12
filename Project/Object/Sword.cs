using System.Text;

namespace Project;

public class Sword : Item, IInteractable
{
    public Sword()
    {
        shape = new Shape[1] ;
        shape[0] = new Shape() { Symbol = new StringBuilder("\0メ"), Color = ConsoleColor.Red};
    }
    
    public override void Use()
    {
    }

    public void Interact(PlayerCharacter player)
    {
        //player.equip sword;
    }
}