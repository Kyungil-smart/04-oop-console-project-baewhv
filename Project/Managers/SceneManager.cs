namespace Project;
//만들어둔 상태들을 관리
//현재 상태
//어떤 상태 객체들?
//상태 변경 기능

public static class SceneManager
{
    //private Scene state = new Scene();
    public static Action OnChangeScene;

    public static Scene Current { get; private set; }

    private static Scene _prev;
    //상태 보관 컨테이너
    //string 키는 부담이 큼. 추후 enum으로 변경 필요.
    private static Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

    public static void AddScene(string key, Scene scene)
    {
        if (_scenes.ContainsKey(key)) return;
        _scenes.Add(key, scene);
    }

    public static void ChangePrevScene()
    {
        Change(_prev);
    }
    public static void Change(string key)
    {
        if (!_scenes.ContainsKey(key)) return;
        Change(_scenes[key]);
    }
    
    public static void Change(Scene scene)
    {
        Scene next = scene;
        if (Current == next) return;

        Current?.Exit();
        next.Enter();
        _prev = Current;
        Current = next;
        OnChangeScene?.Invoke();
    }

    public static void Update()
    {
        Current?.Update();
    }
    public static void Render()
    {
        Current?.Render();
    }
}
