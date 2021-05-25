using System.Collections.Generic;

namespace Assets.Scripts.Game15
{
    public class Coord
    {
        public int x;
        public int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coord(int size)
        {
            x = size - 1;
            y = size - 1;
        }

        public bool OnBoard(int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;

        }

        static public IEnumerable<Coord> YieldCoord(int size)
        {
            for (var y = 0; y < size; y++)
            for (var x = 0; x < size; x++)
                yield return new Coord(x, y);
        }

        public Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }

        public bool Equals(Coord other)
        {
            return x == other.x && y == other.y;
        }
    }
}