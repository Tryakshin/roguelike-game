
namespace roguelike_game;

public class Kinds
{
    public int Health;
    public int Damage;

    public Kinds(int health, int damage) 
    {
        Health = health;
        Damage = damage;
    }

    public static Kinds ChooseKind()
    {

        Kinds warrior = new(15, 5);
        Kinds archer = new(10, 10);
        Kinds mage = new(7, 18);

        Kinds[] kind =
        {
            warrior,
            archer,
            mage,
        };

        int kindNumber;

        Console.Write(" 1 - Warrior (Здоровье: 15; Урон: 10) \n 2 - Archer (Здоровье: 10; Урон: 5) \n 3 - Mage (Здоровье: 7; Урон: 3)");
        Console.Write("\n Выберите номер персонажа: ");
        kindNumber = Convert.ToInt32(Console.ReadLine());
        while (kindNumber > 3 || kindNumber < 1)
        {
            Console.Write("Выбран несуществующий номер класса, выберите существующий: ");
            kindNumber = Convert.ToInt32(Console.ReadLine());

        }

        Kinds Role = kind[kindNumber];
        return Role;


    }

}