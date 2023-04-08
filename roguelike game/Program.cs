using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Threading;

namespace roguelike_game;

internal class Program
{
    private static List<(int, int)> GenerateCoords(int n, int maxX, int maxY)
    {
        var set = new HashSet<(int y, int x)>();
        var rand = new Random();

        while (set.Count < n)
        {
            var y = rand.Next(1, maxY);
            var x = rand.Next(1, maxX);
            if (!set.Contains((y, x)))
            {
                set.Add((y, x));
            }
        }

        return set.ToList();
    }



    private static Game GenerateGame()
    {
        Map map = new Map(50, 20);
        

        Kinds role = Kinds.ChooseKind();

        Player player = new Player(map.Width / 2, map.Height / 2, role);

        Random rand = new Random();
        var monsters = new List<Character>();
        var walls = new List<Entity>();
        var potions = new List<Potion>();
        var exits = new List<Exit>();
        Game game = new Game(map, player, monsters, walls, potions);

        var entitiesCount = map.Width * map.Height / 10;
        var entitiesCoords = GenerateCoords(entitiesCount, map.Width, map.Height);
        var monstersCoords = entitiesCoords.Take(entitiesCoords.Count / 15).ToList();
        var wallCoords = entitiesCoords.Except(monstersCoords).ToList();
        var potionCoords = entitiesCoords.Take(entitiesCoords.Count / 10).Except(monstersCoords).ToList();




        foreach (var (y, x) in monstersCoords)
        {
            monsters.Add(new Character(x, y, rand.Next(1, 5), rand.Next(1, 5)));
        }
        foreach (var (y, x) in wallCoords)
        {
            walls.Add(new Entity(x, y, true, "■"));
        }
        foreach (var (y, x) in potionCoords)
        {
            potions.Add(new Potion(x, y, 0, -10));
        }

        return game;


    }
    private static void Main()
    {
        Console.CursorVisible = false;            
        Game game = GenerateGame();    
        
        while (true)
        {

            game.Map.Draw(game);
            var key = Console.ReadKey(true);
            game.Player.Move(game, key.Key);
            
        }
    }
}