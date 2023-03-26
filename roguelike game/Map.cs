namespace roguelike_game;

public class Map
{
    public readonly int Width;
    public readonly int Height;
    public readonly List<List<Entity>> EntitiesList;

    public Map(int width, int height)
    {
        Width = width - 1;
        Height = height - 1;
        EntitiesList = new List<List<Entity>>();
    }

    private void Generate(Game game)
    {
        EntitiesList.Clear();
        for (var y = 0; y <= Height; ++y)
        {
            EntitiesList.Add(new List<Entity>());
            for (var x = 0; x <= Width; ++x)
            {
                if (y == 0 && x == 0)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '╔'));
                }
                else if (y == 0 && x == Width)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '╗'));
                }
                else if (y == Height && x == 0)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '╚'));
                }
                else if (y == Height && x == Width)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '╝'));
                }
                else if (y == 0 || y == Height)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '═'));
                }
                else if (x == 0 || x == Width)
                {
                    EntitiesList[y].Add(new Entity(x, y, true, '║'));
                }
                else
                {
                    EntitiesList[y].Add(new Entity(x, y, false, ' '));
                }
            }
        }
        EntitiesList[game.Player.Y][game.Player.X] = game.Player;
        foreach (var monster in game.Monsters)
        {
            EntitiesList[monster.Y][monster.X] = monster;
        }
        foreach (var wall in game.Walls)
        {
            EntitiesList[wall.Y][wall.X] = wall;
        }
    }

    public void Draw(Game game)
    {
        Generate(game);
        Console.Clear();
        for (var y = 0; y <= Height; ++y)
        {
            for (var x = 0; x <= Width; ++x)
            {
                Console.ForegroundColor = EntitiesList[y][x].Color;
                Console.Write(EntitiesList[y][x].Symbol);
            }

            if (y != Height)
            {
                Console.WriteLine();
            }
        }
    }
}