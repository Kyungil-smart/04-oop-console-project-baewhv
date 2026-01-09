namespace Project;

public class Screen
{
    private const int _width = 64;
    private const int _height = 18;
    
    private Border _screen;

    public Screen()
    {
        _screen = new Border(width: _width, height: _height);
    }

    public void Render()
    {
        _screen.Draw();
        //이 안에 맵 그리기.
    }
}