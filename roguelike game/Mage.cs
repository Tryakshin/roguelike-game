namespace roguelike_game;

public class Mage : Kinds
{
    public Mage (int health, int damage) : base(health, damage)
    {
        Health = 7;
        Damage = 3;
    }
}