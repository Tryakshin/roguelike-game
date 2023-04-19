using System.Numerics;

namespace roguelike_game;

internal class Program
{
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

        var rand = new Random();
        var map = new Map(50, 25);
        var role = Kinds.ChooseKind();
        var player = new Player(map.Width / 2, map.Height / 2, role);
        var monsters = new List<Character>();
        var walls = new List<Entity>();
        var potions = new List<Potion>();
        var inventory = new Inventory(3);
        LogWriter logWriter = new LogWriter("C:\\Users\\Никита\\source\\repos\\roguelike4\\roguelike game\\assets\\log.txt", false);
        var statusWindow = new StatusWindow(20, 10, 52, 0, player);
        var game = new Game(map, player, monsters, walls, potions, statusWindow, inventory, logWriter);
        var entitiesCount = map.Width * map.Height / 10;
        var entitiesCoords = Game.GenerateCoords(entitiesCount, map.Width, map.Height);
        var monstersCoords = entitiesCoords.Take(entitiesCoords.Count / 15).ToList();
        var potionCoords = entitiesCoords.Except(monstersCoords).Take(entitiesCoords.Count / 10).ToList();
        var wallCoords = entitiesCoords.Except(monstersCoords).Except(potionCoords).ToList();
        game.StatusWindow.Update(game.Player.HP, game.Player.Dmg, game.MonstrsCount(), game.Inventory.InventoryCount());
        

        var Play = Game.GenerateGame(rand, map, role, player, monsters, walls, potions, inventory, logWriter, statusWindow, game, entitiesCount, entitiesCoords, monstersCoords, potionCoords, wallCoords);
        while (true)
        {
            game.Map.Draw(game, player);
            game.StatusWindow.Draw();
            var key = Console.ReadKey(true);
            game.Player.Control(game, key.Key);
            /*player.ControlHealth(10);*/
            /* map.CheckCoordinates(player, game);*/
            game.StatusWindow.Update(game.Player.HP, game.Player.Dmg, game.MonstrsCount(), game.Inventory.InventoryCount());
            if (game.Player.HP <= 0)
            {
                game.GameOver();
                break;
            }
            if (game.MonstrsCount() == 0)
            {
                game.Win();
                break;
            }
        }

    }
}