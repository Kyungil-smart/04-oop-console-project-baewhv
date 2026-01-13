namespace Project;

public class TownMap : Map
{
    public TownMap(Vector startPos) : base(startPos)
    {
        _width = 16;
        _height = 9;
        //SetObject();
        
        SetObject(new Potion(){ Name = "포션", Position = new Vector(4,3)});
        SetObject(new Potion(){ Name = "포션", Position = new Vector(3,3)});
        SetObject(new Potion(){ Name = "포션", Position = new Vector(4,2)});
        SetObject(new Potion(){ Name = "포션", Position = new Vector(3,2)});
        SetObject(new Sword(){ Name = "미스터소드", Position = new Vector(-4,3)});
        SetObject(new NPC("마왕"){Position = new Vector(0,3)});
        
    }
}