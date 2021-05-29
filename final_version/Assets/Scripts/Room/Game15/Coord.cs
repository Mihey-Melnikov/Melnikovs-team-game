using System.Collections.Generic;

public class Coord
{
    public readonly int X;
    public readonly int Y;

    public Coord(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Coord(int size)
    {
        X = size - 1;
        Y = size - 1;
    }

    public bool OnBoard(int size)
    {
        if (X < 0 || X > size - 1) return false;
        return Y >= 0 && Y <= size - 1;
    }

    public static IEnumerable<Coord> YieldCoord(int size)
    {
        for (var y = 0; y < size; y++)
        for (var x = 0; x < size; x++)
            yield return new Coord(x, y);
    }

    public Coord Add(int sx, int sy)
    {
        return new Coord(X + sx, Y + sy);
    }

    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }
}