using System.Text;

namespace Project;

public abstract class GameObject
{
    private GameObject _parent;
    private StringBuilder Symbol;
    public Vector Position { get; set; }

    public GameObject()
    {
        Symbol = new StringBuilder(17);
    }

    public void SetSymbol(char[] symbol)
    {
        Symbol.Clear();
        Symbol.Length = symbol.Length;
        for (int i = 0; i < symbol.Length; i++)
        {
            Symbol[i] = symbol[i];
        }
    }
    
    public void SetParent(GameObject parent)
    {
        _parent = parent;
    }

    // public Vector GetWorldPosition()
    // {
    //     //if()
    // }

    public int GetPriority(int x, int y)
    {
        //-3 -2 -1 0 1 2 3
        // 0 1  2  3 4 5 6
        return (2 * x * Position.Y) + (Position.X + x);
    }
    
}   