using System.Text;

namespace Project;

public class ScreenFrame
{
    private Vector _size;
    private Vector _position = Vector.Zero;
    private Border _screenBorder;
    private StringBuilder[,] _screen;

    private HealthUI _healthUi;
    public Vector GetSize => _size;

    public void SetData((int X, int Y) pos, char[] text)
    {
        if (pos.X >= _size.X || pos.Y >= _size.Y || pos.X < 0 || pos.Y < 0) return;
        _screen[pos.Y, pos.X][1] = '\0';
        for (int i = 0; i < text.Length && i < _screen[pos.Y,pos.X].Length; i++)
        {
            _screen[pos.Y, pos.X][i] = text[i];
        }
    }

    public ScreenFrame(PlayerCharacter player, Vector pos = null)
    {
        if (pos == null) pos = Vector.Zero;
        _size = new Vector(33, 19);
        _screenBorder = new Border(pos, _size);
        _position = pos;
        _screen = new StringBuilder[_size.Y,_size.X];
        for (int y = 0; y < _size.Y; y++)
        {
            for (int x = 0; x < _size.X; x++)
            {
                _screen[y, x] = new StringBuilder(3);
                _screen[y, x].Length = 2;
            }
        }
        _healthUi = new HealthUI();
        _healthUi.Init(player, new Vector(1, _size.Y + 1));
    }

    public void DrawUI() //테두리는 1회만 그린다.
    {
        _screenBorder.Draw();
        _healthUi.DrawUI();
        _healthUi.Render();
    }

    public void Render() //스크린 영역 랜더.
    {
        for (int y = 0; y < _screen.GetLength(0); y++)
        {
            Console.SetCursorPosition(_position.X + 2, _position.Y + 1 + y);
            for (int x = 0; x < _screen.GetLength(1); x++)
            {
                for (int k = 0; k < _screen[y, x].Length; k++)
                {
                    _screen[y,x][k].Print();    
                }
            }
        }
    }
}