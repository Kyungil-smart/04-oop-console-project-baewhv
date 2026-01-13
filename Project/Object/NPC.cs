namespace Project;

public class NPC : GameObject, IInteractable
{
    private int _dialogIndex = 0;
    private string _name;
    private List<string> dialog = new List<string>();

    public NPC(string name)
    {
        _name = name;
    }
    public void Interact(PlayerCharacter player)
    {
        
    }
}