namespace Project;

public class SelectList
{
    private List<(string text, Action action)> _menus;
    private int _currentIndex;
    public int CurrentIndex{get=> _currentIndex;}

    private Border _border;
    private int _maxLength;
    

    public SelectList(params (string, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _menus = new List<(string, Action)>();
        }
        else
        {
            _menus = menuTexts.ToList();
        }
        _border = new Border(width: _maxLength +4, height: _menus.Count + 2);
    }
    public void Add(string text, Action action)
    {
        _menus.Add((text, action));

        int textWidth = text.GetTextWidth();
        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }
        _border.Width = _maxLength;
        _border.Height++;
    }

    public void Remove()
    {
        _menus.RemoveAt(_currentIndex);
        int max = 0;
        
        //테두리 리사이징
        foreach ((string text,Action action) in _menus)
        {
            int textWidth = text.GetTextWidth();
            if (max < textWidth) 
                max = textWidth;
        }

        if (_maxLength != max) _maxLength = max;

        _border.Width = _maxLength + 6;
        _border.Height--;

    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Select()
    {
        if (_menus.Count == 0) return;
        _menus[_currentIndex].action?.Invoke();
        if (_menus.Count == 0)
            _currentIndex = 0;
        if (_currentIndex >= _menus.Count) 
            _currentIndex = _menus.Count - 1;
    }

    public void SelectUp()
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;
        if (_currentIndex >= _menus.Count) _currentIndex = _menus.Count - 1;
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