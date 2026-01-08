namespace Project;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "테스트 RPG";
    private PlayerCharacter _player;
    
    public void Run()
    {
        Init();
        
        while (!IsGameOver)
        {
            Console.Clear();
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
        SceneManager.AddScene("TownScene", new TownScene(_player));
        SceneManager.AddScene("StoryScene", new StoryScene());
        SceneManager.AddScene("Log", new LogScene());
        SceneManager.Change("TitleScene");
    }
}
