namespace Project;

public class StoryScene : Scene
{
    private PlayerCharacter _player;

    private Screen _screen;
    public StoryScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = _player;
        _screen = new Screen();
    }
    
    public override void Enter()
    {
    }

    public override void Update()
    {
        Console.WriteLine("StoryScene Update");
    }
    
    
    public override void Render()
    {
        _screen.Render();
    }

    public override void Exit()
    {
        
    }

}