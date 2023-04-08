namespace roguelike_game;

public class Player : Character
{
    private int _money;
    private Kinds Role;

    public Player(int x, int y, Kinds role, string symbol = "@", ConsoleColor color = ConsoleColor.Red,
        bool collision = true, int money = 0) : base(x, y, role.Health, role.Damage, symbol, color, collision)
    {
        _money = money;
        Role = role;
    }
 

    public void Move(Game game, ConsoleKey key)
    {
        if (key == ConsoleKey.UpArrow)
        {
            if (!game.Map.EntitiesList[Y - 1][X].Collision) Y -= 1;
        }

        if (key == ConsoleKey.DownArrow)
        {
            if (!game.Map.EntitiesList[Y + 1][X].Collision) Y += 1;
        }
        if (key == ConsoleKey.LeftArrow)
        {
            if (!game.Map.EntitiesList[Y][X - 1].Collision) X -= 1;
        }
        if (key == ConsoleKey.RightArrow)
        {
            if (!game.Map.EntitiesList[Y][X + 1].Collision) X += 1;
        }
    }

  


}

