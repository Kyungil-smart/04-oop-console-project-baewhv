namespace Project;

public class StoryScene : Scene
{
    private PlayerCharacter _player;

    private ScreenFrame _screenFrame;
    private HealthUI _healthUi;
    public StoryScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _screenFrame = new ScreenFrame();
        _healthUi = new HealthUI();
        _healthUi.Init(_player, new Vector(1, _screenFrame.MaxSize.Y-1 ));

    }
    
    public override void Enter()
    {
        _screenFrame.DrawUI();
        
        _healthUi.DrawUI();
        _healthUi.Render();
    }

    public override void Update()
    {
        _player.Update();
    }
    
    
    public override void Render()
    {
        
    }

    public override void Exit()
    {
        
    }

}