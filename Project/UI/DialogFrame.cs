namespace Project;

public class DialogFrame
{
    private Vector _size;
    private Vector _pos;
    private Border _screen;
    
    
    public Vector MaxSize => _size;

    public DialogFrame(Vector pos, Vector size)
    {
        _pos = pos;
        _size = size;
        _screen = new Border(pos, size);
    }
    
    public void DrawUI() //테두리는 1회만 그린다.
    {
        _screen.Draw();
    }
    public void Render()
    {
        
    }
}