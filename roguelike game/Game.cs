using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace roguelike_game;

public class Game
{
    public readonly Map Map;
    public readonly Player Player;
    public List<Character> Monsters;
    public readonly List<Entity> Walls;
    public readonly List<Potion> Potions;
    public readonly StatusWindow StatusWindow;
    public readonly Inventory Inventory;
    


    public Game(Map map, Player player, List<Character> monsters, List<Entity> walls, List<Potion> potions, StatusWindow statusWindow, Inventory inventory)
    {
        Map = map;
        Player = player;
        Monsters = monsters;
        Walls = walls;
        Potions = potions;
        StatusWindow = statusWindow;
        Inventory = inventory;
        
    }
    public int MonstrsCount()
    {
        return Monsters.Count;
    }

    /*public int PotionCount()
    {
        return Potions.Count;
    }*/


    public static List<(int, int)> GenerateCoords(int n, int maxX, int maxY)
    {
        var set = new HashSet<(int y, int x)>();
        var rand = new Random();

        while (set.Count < n)
        {
            var y = rand.Next(1, maxY);
            var x = rand.Next(1, maxX);
            if (!set.Contains((y, x)) && y != maxY / 2 && x != maxX / 2)
            {
                set.Add((y, x));
            }
        }

        return set.ToList();
    }

    public static Game GenerateGame(Random rand, Map map, Kinds role, Player player, List<Character> monsters, List<Entity> walls, List<Potion> potions, Inventory inventory, 
        StatusWindow statusWindow, Game game, int entitiesCount, List<(int, int)> entitiesCoords, List<(int, int)> monstersCoords, List<(int, int)> potionCoords, List<(int, int)> wallCoords)
    {


        foreach (var (y, x) in wallCoords)
        {
            walls.Add(new Entity(x, y, true, '#'));
        }


        foreach (var (y, x) in monstersCoords)
        {
            var randomCharacterType = rand.Next(3);
            monsters.Add(Character.CreateCharacter(x, y, randomCharacterType));
        }
        foreach (var (y, x) in potionCoords)
        {
            potions.Add(new Potion(x, y, 0, -10));
        }




        return game;
    }

    public void RemoveItem(Entity entity)
    {
        if (entity.GetType() == typeof(Character))
        {
            Monsters.Remove(entity as Character);
        }

        else if (entity.GetType() == typeof(Potion))
        {
            Potions.Remove(entity as Potion);

        }
    }

    public void Fight(Player character1, Character monster)
    {
        Character character2 = monster;


        int player1Health = character1.HP;
        int player2Health = monster.HP;

        while (player1Health > 0 && player2Health > 0)
        {
            Player attacker = character1;
            Character defender = character2;

            int damage = attacker.Dmg;
            defender.ControlHealth(damage);

            if (defender.HP == 0)
            {
                break;
            }

            attacker = monster as Player;
            damage = monster.Dmg;
            character1.ControlHealth(damage);
        }

        if (character2.HP == 0)
        {

            
            RemoveItem(monster);


        }
        else if (character1.HP == 0)
        {
            Console.WriteLine("Player 2 wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }


    }

    public void GameOver()
    {
        Console.Clear();
        Console.WriteLine("You Lost!");
        LogWriter.WriteLog("Вы проиграли :(");
    }

    public void Win()
    {
        Console.Clear();
        Console.WriteLine("You Won!");
        LogWriter.WriteLog("Ура! Вы выиграли!");
    }



}