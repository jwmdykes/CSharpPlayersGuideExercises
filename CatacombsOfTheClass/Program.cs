Point p1 = new(5f, 3f);
Point p2 = new();

Console.WriteLine(p1);
Console.WriteLine(p2);

internal class Point
{
    public override string ToString() => $"Point(X: {X}, Y: {Y})";
    public float X { get; set; }
    public float Y { get; set; }

    public Point() : this(0, 0)
    {
    }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}