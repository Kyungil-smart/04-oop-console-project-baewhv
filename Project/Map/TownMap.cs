namespace Project;

public class TownMap : Map
{
    public TownMap(Vector startPos) : base(startPos)
    {
        _width = 16;
        _height = 9;
        //SetObject();
        
        SetObject(new Potion(){ Name = "Potion", Position = new Vector(4,3)});
        
    }
}