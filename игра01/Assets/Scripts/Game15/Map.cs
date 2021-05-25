using UnityEngine.Timeline;

namespace Assets.Scripts.Game15
{
    public class Map
    {
        int size;
        int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public void Set(Coord xy, int value)
        {
            if (xy.OnBoard(size))
                map[xy.x, xy.y] = value;
        }

        public int Get(Coord xy)
        {
            return xy.OnBoard(size) ? map[xy.x, xy.y] : 0;
        }
        
        public (int,int) GetValue(int value)
        {
            for (var x = 0;  x < size; ++x)
            for (var y = 0;  y < size; ++x)
                if (map[x, y] == value)
                    return (x, y);
            return (-1,-1);
        }

        public void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}