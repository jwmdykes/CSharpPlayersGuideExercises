// Point p1 = new(5f, 3f);
// p1.X = 15;
// Point p2 = new();
//
// Console.ForegroundColor = ConsoleColor.Red;
// Console.WriteLine(p1);
// Console.WriteLine(p2);
//
// Color c1 = new() { R = 255, G = 0, B = 128 };
// Color c2 = new(1, 2, 3);
// Color c3 = Color.Orange;
//
// Console.ForegroundColor = ConsoleColor.Yellow;
// Console.WriteLine(c1);
// Console.WriteLine(c2);
// Console.WriteLine(c3);

int deckSize = Enum.GetValues(typeof(CardColor)).Length * Enum.GetValues(typeof(CardRank)).Length;
var deck = new Card[deckSize];

var index = 0;
foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
{
    foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
    {
        deck[index] = new Card() { Color = color, Rank = rank };
        index++;
    }
}

foreach (var card in deck)
{
    Console.WriteLine(card);
}


internal enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

internal enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Carrot,
    Ampersand
}

internal class Card
{
    public override string ToString() => $"{Color} {Rank} card.";
    
    public CardColor Color { set; get; }
    public CardRank Rank { set; get; }

    public bool IsSymbolCard => Rank switch
    {
        CardRank.Dollar => true,
        CardRank.Percent => true,
        CardRank.Carrot => true,
        CardRank.Ampersand => true,
        _ => false
    };
}

internal class Color
{
    public static readonly Color White = new(0, 0, 0);
    public static readonly Color Black = new(0xff, 0xff, 0xff);
    public static readonly Color Red = new(0xff, 0, 0);
    public static readonly Color Blue = new(0, 0, 0xff);
    public static readonly Color Green = new(0, 0xff, 0);
    public static readonly Color Orange = new(255, 165, 0);
    public static readonly Color Yellow = new(255, 255, 0);
    public static readonly Color Purple = new(128, 0, 128);

    public override string ToString() => $"#{R:x2}{G:x2}{B:x2}";

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Color() : this(0, 0, 0)
    {
    }

    public Color(byte r, byte g, byte b)
    {
        (R, G, B) = (r, g, b);
    }
}

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