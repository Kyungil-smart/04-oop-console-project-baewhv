namespace Project;

public class Border
{
    public int X;
    public int Y;
    public int Width;
    public int Height;
    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public void DefaultColor()
    {
        Color = ConsoleColor.White;
    }


    public Border(int x = 0, int y = 0, int width = 2, int height = 2)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public Border(Vector pos, Vector size)
    {
        X = pos.X;
        Y = pos.Y;
        Width = size.X;
        Height = size.Y;
    }

    public void Draw()
    {
        if (Width < 2 || Height < 2) return;

        Console.SetCursorPosition(X, Y);
        for (int i = 0; i < Width + 2; i++)
        {
            if (i == 0) "┌─".Print(Color);
            else if (i == Width + 1) "─┒".Print(Color);
            else "──".Print(Color);
        }

        for (int i = 1; i <= Height; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            "│".Print(Color);
            Console.SetCursorPosition(X + (Width + 1) * 2, Y + i);
            " ┃".Print(Color);
        }

        Console.SetCursorPosition(X, Y + Height + 1);
        for (int i = 0; i < Width + 2; i++)
        {
            if (i == 0) "┕━".Print(Color);
            else if (i == Width + 1) "━┛".Print(Color);
            else "━━".Print(Color);
        }
    }
}