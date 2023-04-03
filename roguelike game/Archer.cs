namespace roguelike_game;

public class Archer: Kinds
{
    public Archer(int health, int damage) : base (health, damage)
    {
        Health = health;
        Damage = damage;
    }
}