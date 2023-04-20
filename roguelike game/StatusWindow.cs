


namespace roguelike_game
{
    public class StatusWindow 
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int X;
        public readonly int Y;
        private int _hp;
        private int _damage;
        private int _monstrsCount;
        private int _potionCount;


        public StatusWindow(int width, int height, int x, int y, Player player)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
            
        }

        public void Draw()
        {

            Console.SetCursorPosition(X, Y);
            Console.Write('╔');
            Console.SetCursorPosition(X + Width, Y);
            Console.Write('╗');
            Console.SetCursorPosition(X, Y + Height);
            Console.Write('╚');
            Console.SetCursorPosition(X + Width, Y + Height);
            Console.Write('╝');

            for(int i = X + 1; i< X + Width; i++)
            {
                Console.SetCursorPosition(i,Y);
                Console.Write('═');
                Console.SetCursorPosition(i, Y + Height);
                Console.Write('═');
            }
            for(int i = Y + 1; i < Y + Height;i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write('║');
                Console.SetCursorPosition(X + Width, i);
                Console.Write('║');
            }
            
            var hp = new StreamReader(@"assets\hp.txt");
            int cordX = X + 2;
            int cordY = Y + 1;
            while (!hp.EndOfStream)
            {
               
                Console.SetCursorPosition(cordX,cordY);
                var s = hp.ReadLine();

                Console.Write(s);
                cordY++;
            }

            var crip = new StreamReader(@"assets\Slime.txt");
            while (!crip.EndOfStream)
            {

                Console.SetCursorPosition(cordX, cordY + 2);
                var s = crip.ReadLine();

                Console.Write(s);
                cordY++;
            }

            var pt = new StreamReader(@"assets\potion.txt");
            while (!pt.EndOfStream)
            {

                Console.SetCursorPosition(cordX+12, cordY - 1);
                var s = pt.ReadLine();

                Console.Write(s);
                cordY++;
            }
            Console.SetCursorPosition(56, 2);
            if( _hp <10  )
            {
                Console.WriteLine(" {0}",_hp);
            }
            else { Console.WriteLine(_hp); }
            Console.SetCursorPosition(62, 2);
            Console.Write("Damage:");
            Console.Write(_damage);
            Console.SetCursorPosition(58, 7);
            Console.WriteLine(_monstrsCount);
            Console.SetCursorPosition(67, 6);
            Console.WriteLine(_potionCount);
        }
        public void Update(int playerHP , int playerDmg, int monstrs, int potion)
        {
            _hp = playerHP;
            _damage = playerDmg;
            _monstrsCount = monstrs;
            _potionCount = potion;
        }

    }
}
