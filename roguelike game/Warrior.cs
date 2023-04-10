
namespace roguelike_game;

public class Warrior : Kinds
{
    public Warrior (int health, int damage) : base(health, damage)
    {
        Health = 15;
        Damage = 12;
    }
    
}