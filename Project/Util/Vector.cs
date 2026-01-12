namespace Project;

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector Up => new Vector(0, 1);
    public static Vector Down => new Vector(0, -1);
    public static Vector Left => new Vector(-1, 0);
    public static Vector Right => new Vector(1, 0);
    public static Vector Zero => new Vector(0, 0);
    public static Vector One => new Vector(1, 1);

    public static Vector operator /(Vector a, int value)
        => new (a.X / value, a.Y / value);

    public static Vector operator +(Vector a, Vector b)
        => new (a.X + b.X, a.Y + b.Y);
    public static Vector operator -(Vector a, Vector b)
        => new (a.X - b.X, a.Y - b.Y);
    
    

}