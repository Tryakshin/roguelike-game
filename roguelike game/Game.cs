namespace roguelike_game;

public class Game
{
    public readonly Map Map;
    public readonly Player Player;
    public readonly List<Character> Monsters;
    public readonly List<Entity> Walls;

    public Game(Map map, Player player, List<Character> monsters, List<Entity> walls)
    {
        Map = map;
        Player = player;
        Monsters = monsters;
        Walls = walls;
    }
}