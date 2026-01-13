using System.Text;

namespace Project;

public class SkillIcon
{
    public StringBuilder Icon { get; set; }
    public bool Visible { get; set; }
    public string Key { get; set; }
    public ConsoleColor Color { get; set; }

    public void Render(Vector pos)
    {
        if (!Visible) return;
        Console.SetCursorPosition(pos.X, pos.Y);
        "┌─  ─┐".Print();
        Console.SetCursorPosition(pos.X, pos.Y + 1);
        "│ ".Print();
        for (int i = 0; i < Icon.Length; i++)
        {
            Icon[i].Print(Color);
        }
        " │".Print();
        Console.SetCursorPosition(pos.X, pos.Y + 2);
        "└─  ─┘".Print();
        Console.SetCursorPosition(pos.X+2, pos.Y + 3);
        Key.Print();
    }
}