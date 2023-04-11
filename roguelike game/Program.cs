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
            if (!set.Contains((y, x)) && y != maxY / 2 && x != maxX / 2)
            {
                set.Add((y, x));
            }
        }

        return set.ToList();
    }

    private static Game GenerateGame()
    {
        var rand = new Random();

        var map = new Map(50, 25);
        
        var role = Kinds.ChooseKind();
        var player = new Player(map.Width / 2, map.Height / 2, role);
        var monsters = new List<Character>();
        var walls = new List<Entity>();
        var potions = new List<Potion>();
        var statusWindow = new StatusWindow(20, 10, 52, 0, player);
        var game = new Game(map, player, monsters, walls, potions, statusWindow);
        var entitiesCount = map.Width * map.Height / 10;
        var entitiesCoords = GenerateCoords(entitiesCount, map.Width, map.Height);
        var monstersCoords = entitiesCoords.Take(entitiesCoords.Count / 15).ToList();
        var potionCoords = entitiesCoords.Except(monstersCoords).Take(entitiesCoords.Count / 10).ToList();
        var wallCoords = entitiesCoords.Except(monstersCoords).Except(potionCoords).ToList();

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

        statusWindow.Update(player.HP, player.Dmg, game.MonstrsCount(), game.PotionCount());

        return game;
    }
    private static void Main()
    {
        Console.CursorVisible = false;

        var start = new StreamReader(@"assets/start.txt");
        while (!start.EndOfStream)
        {
            var s = start.ReadLine();

            Console.WriteLine(s);
        }
        start.Close();
        Console.Write("      Press <Enter> to continue... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        Console.Clear();

        var game = GenerateGame();
        while (true)
        {
            game.Map.Draw(game);
            game.StatusWindow.Draw();
            var key = Console.ReadKey(true);
            game.Player.Move(game, key.Key);
        }
    }
}