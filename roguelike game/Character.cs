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
    
    public static Character CreateCharacter(int x, int y, int characterType)
    {
        switch (characterType)
        {
            case 0:
                return new Character(x, y, 50, 5, symbol: 'A');
            case 1:
                return new Character(x, y, 25, 10, symbol: 'B');
            case 2:
                return new Character(x, y, 40, 7, symbol: 'C');
            default:
                throw new ArgumentException($"Invalid character type: {characterType}");
        }
    }
}
