namespace roguelike_game;

public class Player : Character
{
    private int _money;
    public Player(int x, int y, int health, int damage, string symbol = "@", ConsoleColor color = ConsoleColor.Red,
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

    public static void ChooseKind()
    {

        Kinds warrior = new (15, 10);
        Kinds archer = new (10, 5);
        Kinds mage = new (7, 3);

        Kinds[] kind =
        {
            warrior,
            archer,
            mage,
        };

        int kindNumber;

       
        Console.Write(" ╔═══════╗ ╔═══════╗ ╔═══════╗ ╔═══════╗ ╔═══════╗\n");
        Console.Write(" ║ ╔═══╗ ║ ╚══╗ ╔══╝ ║ ╔═══╗ ║ ║ ╔═══╗ ║ ╚══╗ ╔══╝\n");
        Console.Write(" ║ ║   ╚═╝    ║ ║    ║ ╚═══╝ ║ ║ ╚═══╝ ║    ║ ║ \n");
        Console.Write(" ║ ╚═════╗    ║ ║    ║ ╔═══╗ ║ ║ ╔═══╗╔╝    ║ ║ \n");
        Console.Write(" ╚═════╗ ║    ║ ║    ║ ║   ║ ║ ║ ║   ║╚╗    ║ ║ \n");
        Console.Write(" ╔═╗   ║ ║    ║ ║    ║ ║   ║ ║ ║ ║   ║ ║    ║ ║ \n");
        Console.Write(" ║ ╚═══╝ ║    ║ ║    ║ ║   ║ ║ ║ ║   ║ ║    ║ ║ \n");
        Console.Write(" ╚═══════╝    ╚═╝    ╚═╝   ╚═╝ ╚═╝   ╚═╝    ╚═╝\n");
        Console.Write("Press <Enter> to continue... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        Console.Clear();

        StreamReader Warrior = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\Warrior.txt");
        while (!Warrior.EndOfStream)
        {
            string s = Warrior.ReadLine();
            
            Console.WriteLine(s);
        }
        Warrior.Close();
        Console.Write("A<-  Warrior: 15♥ 10DMG  ->D ");
        while (Console.ReadKey().Key != ConsoleKey.D) { }
        Console.Clear();

        if (Console.ReadKey().Key == ConsoleKey.D)
        {
            Console.Clear();

            StreamReader Mage = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\Wizard.txt");
            while (!Mage.EndOfStream)
            {
                string s = Mage.ReadLine();

                Console.WriteLine(s);
            }
            Mage.Close();
            Console.Write("A<-  Mage: 7♥ 3DMG  ->D ");
            while (Console.ReadKey().Key != ConsoleKey.D) { }
            Console.Clear();

        } 
        else if (Console.ReadKey().Key == ConsoleKey.A)
        {

            while (Console.ReadKey().Key != ConsoleKey.D) { }
            Console.Clear();
            StreamReader Archer = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\Archer.txt");
            while (!Archer.EndOfStream)
            {
                string s = Archer.ReadLine();

                Console.WriteLine(s);
            }
            Archer.Close();
            Console.Write("A<-  Archer: 10♥ 5DMG  ->D ");
        }
       


        /*while (Console.ReadKey().Key != ConsoleKey.D) { }
        Console.Clear();

        StreamReader Mage = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\Wizard.txt");
        while (!Mage.EndOfStream)
        {
            string s = Mage.ReadLine();
            
            Console.WriteLine(s);
        }
        Mage.Close();
        Console.Write("A<-  Mage: 7♥ 3DMG  ->D ");
        while (Console.ReadKey().Key != ConsoleKey.D) { }
        Console.Clear();

        StreamReader Archer = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\Archer.txt");
        while (!Archer.EndOfStream)
        {
            string s = Archer.ReadLine();
            
            Console.WriteLine(s);
        }
        Archer.Close();
        Console.Write("A<-  Archer: 10♥ 5DMG  ->D ");
        while (Console.ReadKey().Key != ConsoleKey.D) { }
        Console.Clear();*/





        /*Console.Write(" 1 - Warrior (Здоровье: 15; Урон: 10) \n 2 - Archer (Здоровье: 10; Урон: 5) \n 3 - Mage (Здоровье: 7; Урон: 3)");
        Console.Write("\n Выберите номер персонажа: ");
        kindNumber = Convert.ToInt32(Console.ReadLine());
        while (kindNumber > 3 || kindNumber < 1)
        {
            Console.Write("Выбран несуществующий номер класса, выберите существующий: ");
            kindNumber = Convert.ToInt32(Console.ReadLine());

        }*/

    }
}