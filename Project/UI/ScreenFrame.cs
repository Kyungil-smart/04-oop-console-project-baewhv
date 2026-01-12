using System.Text;

namespace Project;

public class ScreenFrame
{
    private Vector _size = new Vector(32, 18);
    private Vector _position = Vector.Zero;
    private Border _screenBorder;
    private StringBuilder[] _screen;

    private HealthUI _healthUi;
    public Vector GetSize => _size;

    public void SetData() //덮어쓰기가 아닌 강제로 칠할 부분.
    {
    }

    public ScreenFrame(PlayerCharacter player, Vector pos = null)
    {
        if (pos == null) pos = Vector.Zero;
        _screenBorder = new Border(pos, _size);

        _position = pos;
        _screen = new StringBuilder[_size.Y];
        for (int i = 0; i < _size.Y; i++)
        {
            _screen[i] = new StringBuilder("＃＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＆＃", _size.X / 2);
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
        for (int i = 0; i < _screen.Length; i++)
        {
            Console.SetCursorPosition(_position.X + 2, _position.Y + 1 + i);
            for (int j = 0; j < _screen[i].Length; j++)
            {
                
                _screen[i][j].Print();
            }
        }
    }
}