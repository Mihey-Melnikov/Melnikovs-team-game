namespace Assets.Scripts.Game15
{
    public class Map
    {
        private readonly int size;
        private readonly int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public void Set(Coord xy, int value)
        {
            if (xy.OnBoard(size))
                map[xy.X, xy.Y] = value;
        }

        public int Get(Coord xy)
        {
            return xy.OnBoard(size) ? map[xy.X, xy.Y] : 0;
        }

        public void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}