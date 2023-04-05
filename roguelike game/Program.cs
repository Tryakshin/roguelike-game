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
        

        Kinds role = Kinds.ChooseKind();

        var player = new Player(map.Width / 2, map.Height / 2, role);

        var map = new Map(Console.WindowWidth, Console.WindowHeight);
        var monsters = new List<Character>();
        var walls = new List<Entity>();
        var potions = new List<Potion>();
        
        Game game = new Game(map, player, monsters, walls, potions);

        var entitiesCount = map.Width * map.Height / 10;
        var entitiesCoords = GenerateCoords(entitiesCount, map.Width, map.Height);
        var monstersCoords = entitiesCoords.Take(entitiesCoords.Count / 15).ToList();
        var wallCoords = entitiesCoords.Except(monstersCoords).ToList();
        var potionCoords = entitiesCoords.Take(entitiesCoords.Count / 10).Except(monstersCoords).ToList();


        foreach (var (y, x) in monstersCoords)
        {
            var randomCharacterType = rand.Next(3);
            monsters.Add(Character.CreateCharacter(x, y, randomCharacterType));
        }
        foreach (var (y, x) in wallCoords)
        {
            walls.Add(new Entity(x, y, true, '■'));
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

        StreamReader start = new StreamReader("C:\\Users\\Danil\\Desktop\\Models\\start.txt");
        while (!start.EndOfStream)
        {
            string s = start.ReadLine();

            Console.WriteLine(s);
        }
        start.Close();
        Console.Write("      Press <Enter> to continue... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        Console.Clear();

        Game game = GenerateGame();    
        
        while (true)
        {
            game.Map.Draw(game);
            var key = Console.ReadKey(true);
            game.Player.Move(game, key.Key);
        }
    }
}