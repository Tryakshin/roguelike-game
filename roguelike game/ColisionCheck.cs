

namespace roguelike_game
{
    internal class ColisionCheck
    {

        Boolean Check(Entity entity1, Entity entity2)
        {
            return entity1.X == entity2.X && entity1.Y == entity2.Y;
            
        }
    }
}
