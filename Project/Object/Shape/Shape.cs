using System.Text;

namespace Project;

public enum CollisionType
{
    None,
    Obstacle,
    NPC,
    Enemy,
}

public class Shape
{
    public StringBuilder Symbol;
    public Vector Position = Vector.Zero;
    public CollisionType Type = CollisionType.None;
    public ConsoleColor Color = ConsoleColor.White;
}