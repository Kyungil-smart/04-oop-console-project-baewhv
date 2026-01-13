namespace Project;

public class ItemList
{
    protected List<(string text, Action action)> _menus;
    protected int _currentIndex;
    protected Border _border;
    protected int _maxLength;
    protected int _minWidth = 10;
    protected Vector _pos;

    public int CurrentIndex
    {
        get => _currentIndex;
    }

    protected ItemList()
    {
    }

    public ItemList(Vector pos, Vector size, params (string, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _menus = new List<(string, Action)>();
        }
        else
        {
            _menus = menuTexts.ToList();
        }

        _pos = pos;
        size.X = _minWidth;
        _border = new Border(pos, size);
    }

    public virtual void Add(string text, Action action)
    {
        _menus.Add((text, action));
        int textWidth = text.GetTextWidth();
        if (_minWidth <= textWidth && _maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _border.Width = _maxLength;
    }

    public virtual void Remove()
    {
        _menus.RemoveAt(_currentIndex);
        int max = _minWidth;
        //테두리 리사이징
        foreach ((string text, Action action) in _menus)
        {
            int textWidth = text.GetTextWidth();
            if (_minWidth <= max && max < textWidth)
                max = textWidth;
        }

        if (_maxLength != max) _maxLength = max;

        _border.Width = _maxLength;
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

    public void Render()
    {
        _border.Draw();
        for (int i = 0; i < _menus.Count; i++)
        {
            Console.SetCursorPosition(_pos.X + 2, _pos.Y + 1 + i);
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