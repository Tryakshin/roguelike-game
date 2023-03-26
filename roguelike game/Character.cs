namespace roguelike_game;

public class Character : Entity
{
    protected int Health;
    protected int Damage;

    public Character(int x, int y, int health, int damage, char symbol = 'M', 
        ConsoleColor color = ConsoleColor.Magenta, bool collision = true)
        : base(x, y, collision, symbol, color)
    {
        Health = health;
        Damage = damage;
        X = x;
        Y = y;
        Collision = true;
        Symbol = symbol;
        Color = color;
    }
}
