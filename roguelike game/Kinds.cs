﻿
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

        Kinds warrior = new(15, 10);
        Kinds archer = new(10, 10);
        Kinds mage = new(7, 18);

        var kind = new []
        {
            mage,
            warrior,
            archer,      
        };

        var roles = new StreamReader(@"assets\KindSelection.txt");
        while (!roles.EndOfStream)
        {
            var s = roles.ReadLine();
            Console.WriteLine(s);
        }
        var kindNumber = Console.ReadLine();


        
        switch (kindNumber)
        {
            case "1":
                int i = Convert.ToInt32(kindNumber);
                return kind[i - 1];
            case "2":
                i = Convert.ToInt32(kindNumber);
                return kind[i - 1];
            case "3":
                i = Convert.ToInt32(kindNumber);
                return kind[i - 1];
            default:
                throw new ArgumentException($"Invalid character type: {kindNumber}");
        }     
    }

}