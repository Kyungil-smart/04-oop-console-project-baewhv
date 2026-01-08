namespace Project.UI;

public class Border
{
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public Border(int x = 0, int y = 0, int width = 2, int height = 2)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        if (Width < 2 || Height < 2) return;
        int bw = Console.BufferWidth;
        int bh = Console.BufferHeight;
        
        Console.SetCursorPosition(X, Y);
        for (int i = 0; i < Width; i++)
        {
            if (i == 0)  '┌'.Print();
            else if( i == Width-1) '┒'.Print();
            else '─'.Print();
        }

        for (int i = 1; i < Height - 1; i++)
        {
            Console.SetCursorPosition(X, Y+i);
            '│'.Print();
            for (int j = 1; j < Width-1; j++)
            {
                Console.SetCursorPosition(X+j, Y+i);
                ' '.Print();
            }
            Console.SetCursorPosition(X + Width-1, Y+i);
            '┃'.Print();
        }
        
        Console.SetCursorPosition(X, Y+Height-1);
        for (int i = 0; i < Width; i++)
        {
            if (i == 0)  '┕'.Print();
            else if( i == Width-1) '┛'.Print();
            else '━'.Print();
        }
    }
}