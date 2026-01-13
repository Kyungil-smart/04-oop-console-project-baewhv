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
        SkillIcon icon = player.SkillFrame.GetSkillIcon("Attack");
        icon.Icon = shape[0].Symbol;
        icon.Visible = true;
        icon.Color = shape[0].Color;
        player.SkillFrame.Render();
    }
}