public static class InputManager
{
    private static ConsoleKey _current;

    //게임에서 지원하는 키만 정리.
    private static readonly ConsoleKey[] _keys =
    {
        ConsoleKey.UpArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.Enter,
        ConsoleKey.I,
        ConsoleKey.L,
        ConsoleKey.Subtract,
        ConsoleKey.Add,
    };

    public static bool GetKey(ConsoleKey input)
    {
        return _current == input;
    }

    //GM에서 호출
    public static void GetUserInput()
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        _current = ConsoleKey.Clear;

        foreach (ConsoleKey key in _keys)
        {
            if (key == input)
            {
                _current = input;
                break;
            }
        }
    }

    public static void ResetKey()
    {
        _current = ConsoleKey.Clear;
    }
}