namespace Project;

public class StoryScene : Scene
{
    private PlayerCharacter _player;

    private ScreenFrame _screenFrame;
    private DialogFrame _dialogFrame;
    private Map _townMap;
    public StoryScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _townMap = new TownMap(Vector.Zero);
        _player._map = _townMap;
        _screenFrame = new ScreenFrame(_player);
        _dialogFrame = new DialogFrame(new Vector(0,_screenFrame.GetSize.Y+2), new Vector(_screenFrame.GetSize.X, 5));

        _player.Position = _townMap.StartPos;

    }
    
    public override void Enter()
    {
        _screenFrame.DrawUI();
        _dialogFrame.DrawUI();
    }

    public override void Update()
    {
        _player.Update();
    }
    
    
    public override void Render()
    {
        _townMap.SetScreen(_screenFrame, _player);
        _screenFrame.Render();
        _player.Render();
    }

    public override void Exit()
    {
        
    }

}