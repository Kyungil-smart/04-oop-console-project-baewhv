namespace Project;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "그래서 녹색옷이 젤....";
    private PlayerCharacter _player;
    
    public void Run()
    {
        Init();
        
        while (!IsGameOver)
        {
            SceneManager.Render();
            InputManager.GetUserInput();

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }
            
            SceneManager.Update();
        }
        
    }

    private void Init()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();
        Console.CursorVisible = false;
        SceneManager.AddScene("TitleScene", new TitleScene());
        SceneManager.AddScene("TownScene", new StoryScene(_player));
        SceneManager.AddScene("StoryScene", new StoryScene(_player));
        SceneManager.AddScene("Log", new LogScene());
        SceneManager.AddScene("Test", new LogScene());
        SceneManager.Change("TitleScene");
    }
}
