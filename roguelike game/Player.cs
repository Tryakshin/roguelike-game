using System.Security.Cryptography.X509Certificates;

namespace roguelike_game;

public class Player : Character
{
    public ColisionCheck colisionCheck = new ColisionCheck();
    private int _money;
    private Kinds _role;
    private int _potionCount;
    public Inventory inventory = new Inventory(3);





    public Player(int x, int y, Kinds role, char symbol = '@', ConsoleColor color = ConsoleColor.Red,
        bool collision = true, int money = 0, int potionCount = 0) : base(x, y, role.Health, role.Damage, symbol, color, collision)
    {

        _money = money;
        _role = role;
        _potionCount = potionCount;


        /* void UsePotion(Potion potion)
         {

         }*/
    }


    public void Control(Game game, ConsoleKey key)
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
        if (key == ConsoleKey.P && game.Inventory.InventoryCount() > 0 && Health < MaxHP())
        {
            if (Health + 5 > MaxHP()) Health = MaxHP();
            else ControlHealth(-5);
            game.Inventory.RemoveItem();
            LogWriter.WriteLog("вы лечитесь");
        }

    }

    public int MaxHP()
    {
        return _role.Health;
    }
}

