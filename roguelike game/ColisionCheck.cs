

namespace roguelike_game
{
    public class ColisionCheck
    {
        Boolean Check(Character character1, Character character2)
        {
            return character1.X == character2.X && character1.Y == character2.Y;

        }


        

    }


}
