namespace roguelike_game;

public class Entity
{
    public int X;
    public int Y;
    public string Symbol;
    public ConsoleColor Color;
    public bool Collision;
    
    public Entity(int x, int y, bool collision, string symbol, ConsoleColor color = ConsoleColor.White)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        Color = color;
        Collision = collision;
    }
}