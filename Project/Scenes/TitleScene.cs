namespace Project;

public class TitleScene : Scene
{
    private ResizeList _titleMenu;

    public TitleScene()
    {
        Init();
    }

    public void Init()
    {
        _titleMenu = new ResizeList();
        _titleMenu.Add("게임 시작", GameStart);
        _titleMenu.Add("크레딧", ViewCredits);
        _titleMenu.Add("게임 종료", GameQuit);
    }

    public override void Enter()
    {
        _titleMenu.Reset();
        Debug.Log("타이틀 진입");
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _titleMenu.SelectUp();
        }
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _titleMenu.SelectDown();
        }
        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }
    }
    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        Console.WriteLine(GameManager.GameName);

        _titleMenu.Render(8, 5);

    }

    public override void Exit()
    {
        Debug.Log("타이틀 이탈");
    }
    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }
    public void GameStart()
    {
        SceneManager.Change("TownScene");
    }
    public void ViewCredits()
    {

    }
}
