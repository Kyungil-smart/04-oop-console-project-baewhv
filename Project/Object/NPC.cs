using System.Text;

namespace Project;

public class NPC : GameObject, IInteractable
{
    private int _dialogIndex = 0;
    private string _name;
    private List<string> dialog = new List<string>();

    public NPC(string name)
    {
        _name = name;
        shape = new Shape[2];
        shape[0] = new Shape()
                { Position = new Vector(0, 0), Symbol = new StringBuilder("⟆⟅"), Type = CollisionType.Obstacle};
        shape[1] = new Shape()
            { Position = new Vector(0, -1), Symbol = new StringBuilder("\u2620"), Type = CollisionType.Obstacle};
    }
    public void Interact(PlayerCharacter player)
    {
        Console.Clear();
        Console.WriteLine("승리!");
        Console.ReadKey();
        GameManager.IsGameOver = true;
    }
}