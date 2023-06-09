﻿namespace roguelike_game;

public class Potion : Entity
{
    protected int Health;
    protected int Damage;

    public Potion(int x, int y, int health, int damage, char symbol = 'P',
        ConsoleColor color = ConsoleColor.Yellow, bool collision = true)
        : base(x, y, collision, symbol, color)
    {
        Health = health;
        Damage = damage;
        X = x;
        Y = y;
        Collision = false;
        Symbol = symbol;
        Color = color;
    }   
}