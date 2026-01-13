namespace Project;

public class ResizeList : ItemList
{
    //private int _maxLength;


    public ResizeList(params (string, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _menus = new List<(string, Action)>();
        }
        else
        {
            _menus = menuTexts.ToList();
        }

        _minWidth = 0;
        _border = new Border(width: _maxLength + 4, height: _menus.Count);
    }

    public override void Add(string text, Action action)
    {
        base.Add(text, action);
        _border.Height++;
    }

    public override void Remove()
    {
        base.Remove();

        _border.Height--;
    }
    
    public void Render(int x, int y)
    {
        _border.X = x;
        _border.Y = y;
        _border.Draw();
        
        for (int i = 0; i < _menus.Count; i++)
        {
            y++;
            Console.SetCursorPosition(x+2, y);
            if (i == _currentIndex)
            {
                "->".Print(ConsoleColor.Green);
                _menus[i].text.Print(ConsoleColor.Green);
            }
            else
            {
                Console.Write("  ");
                _menus[i].text.Print();
            }
        }
    }
}