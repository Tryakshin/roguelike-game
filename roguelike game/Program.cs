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
        var rand = new Random();
        
        var map = new Map(50, 20);
        var player = new Player(map.Width / 2, map.Height / 2, 100, 10);
        var monsters = new List<Character>();
        var walls = new List<Entity>();
        var game = new Game(map, player, monsters, walls);

        var entitiesCount = map.Width * map.Height / 10;
        var entitiesCoords = GenerateCoords(entitiesCount, map.Width, map.Height);
        var monstersCoords = entitiesCoords.Take(entitiesCoords.Count / 15).ToList();
        var wallCoords = entitiesCoords.Except(monstersCoords).ToList();


        foreach (var (y, x) in monstersCoords)
        {
            monsters.Add(new Character(x, y, rand.Next(1, 50), rand.Next(1, 5)));
        }
        foreach (var (y, x) in wallCoords)
        {
            walls.Add(new Entity(x, y, true,'#'));
        }
        return game;
    }
    private static void Main()
    {
        var game = GenerateGame();
        while (true)
        {
            game.Map.Draw(game);
            var key = Console.ReadKey(true);
            game.Player.Move(game, key.Key);
        }
    }
}