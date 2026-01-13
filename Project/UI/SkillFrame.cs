using System.Text;

namespace Project;

public class SkillFrame
{
    private Vector _size;
    private Vector _pos;
    private Border _screen;

    private Dictionary<string, SkillIcon> _skills = new Dictionary<string, SkillIcon>();
    
    public Vector MaxSize => _size;

    public SkillFrame(Vector pos, Vector size)
    {
        _pos = pos;
        _size = size;
        _screen = new Border(pos, size);
        _skills["Interact"] = new SkillIcon(){Icon = new StringBuilder("👄"), Key = "F", Visible = true};
        _skills["Attack"] = new SkillIcon(){Key = "Space", Visible = false};
    }

    public SkillIcon GetSkillIcon(string index)
    {
        return _skills[index];
    }
    
    public void DrawUI() //테두리는 1회만 그린다.
    {
        _screen.Draw();
    }
    public void Render()
    {
        int x = 0;
        foreach (KeyValuePair<string, SkillIcon> icon in _skills)
        {
            if (icon.Value.Visible == false) continue; 
            icon.Value.Render(_pos + (x * 6 + 1,2));
            x++;
        }
    }
}