namespace Project;

public class StoryScene : Scene
{
    private PlayerCharacter _player;

    private ScreenFrame _screenFrame;
    private DialogFrame _dialogFrame;
    private SkillFrame _skillFrame;
    private Map _townMap;
    public StoryScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _townMap = new TownMap(Vector.Zero);
        _player.CurrentMap = _townMap;
        _screenFrame = new ScreenFrame(_player);
        _player._inventory._itemMenu =
            new ItemList(new Vector(_screenFrame.GetSize.X*2 + 4, 0), new Vector(0, _screenFrame.GetSize.Y));
        _dialogFrame = new DialogFrame(new Vector(0,_screenFrame.GetSize.Y+2), new Vector(_screenFrame.GetSize.X, 5));
        _skillFrame= new SkillFrame(new Vector(0,_screenFrame.GetSize.Y+2), new Vector(_screenFrame.GetSize.X, 5));
        
        _player.SkillFrame = _skillFrame;
        _player.Position = _townMap.StartPos;

    }
    
    public override void Enter()
    {
        _screenFrame.DrawUI();
        //_dialogFrame.DrawUI();
        _skillFrame.DrawUI();
        _skillFrame.Render();
        _player._inventory._itemMenu.Render();
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