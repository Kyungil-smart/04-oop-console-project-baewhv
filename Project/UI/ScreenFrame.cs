namespace Project;

public class ScreenFrame
{
    private Vector _size = new Vector(32, 18);
    private Border _screen;
    
    
    public Vector MaxSize => _size;

    public ScreenFrame()
    {
        _screen = new Border(width: _size.X, height: _size.Y);
    }
    public void DrawUI() //테두리는 1회만 그린다.
    {
        _screen.Draw();
    }
    public void Render()
    {
        
    }
}