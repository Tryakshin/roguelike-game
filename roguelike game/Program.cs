
class Game
{
    public Map map;
    public Player player;
    public List<Character> monsters;
}
class Map
{
    public int width;
    public int height;
    private List<List<Entity>> _map = new List<List<Entity>>();

}
class Entity
{
    public int x;
    public int y;
    public char symbol;
    public bool collision;
}
class Character : Entity
{
    private int _helth;
    private int _damage;
}
class Player : Character
{
    private int _money;
}
internal class Program
{
    static void Main(string[] args)
    {
    }
}