using System.Text;

namespace Project;

public abstract class GameObject
{
    private GameObject _parent;

    //public StringBuilder Symbol { get; set; }
    public Shape[] shape;
    public Vector Position { get; set; }
    
    public int GetPriority(int x, int y)
    {
        return (2 * x * Position.Y) + (Position.X + x);
    }
    
}   