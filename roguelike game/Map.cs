using System.Numerics;
using System.Transactions;

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

    private void Generate(Game game, Player player)
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
        
        foreach (var potion in game.Potions)
        {
            EntitiesList[potion.Y][potion.X] = potion;

            if (player.X == potion.X && player.Y == potion.Y)
            {

            }

        }
        foreach (var wall in game.Walls)
        {
            EntitiesList[wall.Y][wall.X] = wall;
        }
        foreach (var monster in game.Monsters)
        {
            if (monster.InVisibleDistance(game.Player))
            {
                monster.MoveToEntity(game.Map, game.Player);
            }
            EntitiesList[monster.Y][monster.X] = monster;
        }


        EntitiesList[player.Y][player.X] = game.Player;


        Entity entity = EntitiesList[player.Y][player.X];

        if (entity.GetType() != typeof(Player) && entity != null)
        {
            Game.Fight(player, EntitiesList);
            EntitiesList[player.Y][player.X] = null;

        }
    }

    public void Draw(Game game, Player player)
    {
        Generate(game, player);
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

    

    

   /* public bool CheckCoordinates(Player player, Game game)
    {
        int playerX = player.X;
        int playerY = player.Y;
      

        Entity entity = EntitiesList[playerY][playerX];
        if (entity == null)
        {
            return true;
        }

        if (entity.GetType() != typeof(Player))
        {
            Game.Fight(player, EntitiesList[playerY][playerX] as Character);
            return false;
        }

        return true;
    }*/
}
