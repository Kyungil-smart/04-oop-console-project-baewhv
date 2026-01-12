namespace Project;

public class StoryScene : Scene
{
    private PlayerCharacter _player;

    private ScreenFrame _screenFrame;
    public StoryScene(PlayerCharacter player) => Init(player);

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _screenFrame = new ScreenFrame(_player);
    }
    
    public override void Enter()
    {
        _screenFrame.DrawUI();
    }

    public override void Update()
    {
        _player.Update();
    }
    
    
    public override void Render()
    {
        _screenFrame.Render();
        //맵을 스크린에 등록
        //범위 내 오브젝트를 스크린에 등록
        //렌더
    }

    public override void Exit()
    {
        
    }

}