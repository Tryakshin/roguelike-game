namespace roguelike_game;

public class Player : Character
{
    private int _money;
    public Player(int x, int y, int health, int damage, char symbol = '@', ConsoleColor color = ConsoleColor.Red,
        bool collision = true, int money = 0) : base(x, y, health, damage, symbol, color, collision)
    {
        Health = health;
        Damage = damage;
        
        X = x;
        Y = y;
        Symbol = symbol;
        Collision = collision;
        _money = money;
    }
    
    public void Move(Game game, ConsoleKey key)
    {
        if (key == ConsoleKey.UpArrow)
        {
            if (!game.Map.EntitiesList[Y - 1][X].Collision) Y -= 1;
        }
        else if (key == ConsoleKey.DownArrow)
        {
            if (!game.Map.EntitiesList[Y + 1][X].Collision) Y += 1;
        }
        else if (key == ConsoleKey.LeftArrow)
        {
            if (!game.Map.EntitiesList[Y][X - 1].Collision) X -= 1;
        }
        else if (key == ConsoleKey.RightArrow)
        {
            if (!game.Map.EntitiesList[Y][X + 1].Collision) X += 1;
        }
    }

    public static void ChooseKind()
    {

        Kinds warrior = new(15, 10);
        Kinds archer = new Kinds(10, 5);
        Kinds mage = new Kinds(7, 3);

        Kinds[] kind =
        {
            warrior,
            archer,
            mage,
        };

        int kindNumber;

        Console.Write(" 1 - Warrior (��������: 15; ����: 10) \n 2 - Archer (��������: 10; ����: 5) \n 3 - Mage (��������: 7; ����: 3)");
        Console.Write("\n �������� ����� ���������: ");
        kindNumber = Convert.ToInt32(Console.ReadLine());
        while (kindNumber > 3 || kindNumber < 1)
        {
            Console.Write("������ �������������� ����� ������, �������� ������������: ");
            kindNumber = Convert.ToInt32(Console.ReadLine());

        }

    }
}