namespace Project;

public class TownScene : Scene
{

    private Tile[,] _field = new Tile[10, 20];

    private PlayerCharacter _player;
    public TownScene(PlayerCharacter player) => Init(player);
    
    public void Init(PlayerCharacter player)
    {
        _player = player;
        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                Vector pos = new Vector(j, i);
                _field[i, j] = new Tile(pos);
            }
        }
    }
    public override void Enter()
    {
        _player.Field = _field;
        _player.Position = new Vector(5, 5);
        _field[_player.Position.Y, _player.Position.X].OnTileObject = _player;
        
        _field[3, 5].OnTileObject = new Potion() { Symbol = 'I', Name = "Potion" };
        _field[4, 9].OnTileObject = new Potion() { Symbol = 'I', Name = "Potion 2" };
        _field[6, 7].OnTileObject = new Potion() { Symbol = 'I', Name = "Potion 2" };
    }


    public override void Update()
    {
        _player.Update();
    }

    public override void Render()
    {
        PrintField();
        _player.Render();
    }

    public override void Exit()
    {
        _field[_player.Position.Y, _player.Position.X].OnTileObject = null;
        _player.Field = null;
    }

    private void PrintField()
    {
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                _field[y, x].Print();
            }
            Console.WriteLine();
        }
    }
}