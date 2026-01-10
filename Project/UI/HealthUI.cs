namespace Project;

public class HealthUI
{
    private static readonly string[] heart = new[] { "--", "\u2580-", "\u2588-", "\u2588\u2584", "\u2588\u2588" };
        //'\u2598', '\u258c', '\u2599', '\u2588' , '\u2584'};
    private Vector Position;
    private int _MaxHp;
    private int _hp;

    public void Init(PlayerCharacter character, Vector UIPos)
    {
        _MaxHp = character._health.Value;
        _hp = character._health.Value;
        character._health.AddListener(SetHeath);
        Position = UIPos;
    }

    public void SetHeath(int value)
    {
        _hp = value;
        Render();
    }

    public void DrawUI()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        '['.Print();
        Console.SetCursorPosition(Position.X + _MaxHp, Position.Y);
        ']'.Print();
    }
    
    public void Render()
    {
        Console.SetCursorPosition(Position.X+1, Position.Y);
        int temp = _hp;
        int maxTemp = _MaxHp;
        while (maxTemp >= 0)
        {
            if (temp - 4 >= 0)
            {
                heart[4].Print(ConsoleColor.Red);
            }
            else
            {
                if (temp < 0) temp = 0;
                heart[temp].Print(ConsoleColor.Red);
            }
            temp -= 4;
            maxTemp -= 4;
        }
    }
}