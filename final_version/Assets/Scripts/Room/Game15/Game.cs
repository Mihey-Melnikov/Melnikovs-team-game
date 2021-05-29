using System;
using Assets.Scripts.Game15;

public class Game
{
    private readonly int size;
    private readonly Map map;
    private Coord space;
    private int Moves { get; set; }

    public Game(int size)
    {
        this.size = size;
        map = new Map(size);
    }

    public void Start()
    {
        var random = new Random();
        var seed = random.Next(50, 500);
        var digit = 0;
        foreach (var xy in Coord.YieldCoord(size))
            map.Set(xy, ++digit);
        space = new Coord(2, 2);
        if (seed > 0)
            Shuffle(seed);
        Moves = 0;
    }

    private void Shuffle(int seed)
    {
        var random = new Random(seed);
        for (var j = 0; j < seed; j++)
            PressAt(random.Next(size), random.Next(size));
    }

    public void PressAt(int x, int y)
    {
        PressAt(new Coord(x, y));
    }

    private void PressAt(Coord xy)
    {
        if (space.Equals(xy)) return;
        if (xy.X != space.X &&
            xy.Y != space.Y)
            return;

        var steps = Math.Abs(xy.X - space.X) +
                    Math.Abs(xy.Y - space.Y);

        while (xy.X != space.X)
            Shift(Math.Sign(xy.X - space.X), 0);

        while (xy.Y != space.Y)
            Shift(0, Math.Sign(xy.Y - space.Y));

        Moves += steps;
    }

    private void Shift(int sx, int sy)
    {
        var next = space.Add(sx, sy);
        map.Copy(next, space);
        space = next;
    }

    public int GetDigitAt(int x, int y)
    {
        return GetDigitAt(new Coord(x, y));
    }

    private int GetDigitAt(Coord xy)
    {
        return space.Equals(xy) ? 0 : map.Get(xy);
    }
}