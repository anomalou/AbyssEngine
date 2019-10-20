using System;

namespace ConsoleApplication
{
    class Vector
    {
        int x;
        int y;

        _Direction direction;
        public enum _Direction
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }
        
        public Vector()
        {

        }
        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector(int x, int y, _Direction dir)
        {
            this.x = x;
            this.y = y;
            direction = dir;
        }
        public Vector SetVector(int x, int y)
        {
            Vector v = new Vector(x, y);
            return v;
        }
        public Vector SetVector(int x, int y, _Direction dir)
        {
            Vector v = new Vector(x, y, dir);
            return v;
        }

        public int X()
        {
            return x;
        }
        public int Y()
        {
            return y;
        }
        public _Direction Direction()
        {
            return direction;
        }
    }
}
