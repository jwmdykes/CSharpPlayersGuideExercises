var number = Convert.ToInt32(Console.ReadLine());

// Statement form
switch (number)
{
    case 0:
        Console.WriteLine("You gave me a zero");
        break;
    case 1:
        Console.WriteLine("You gave me a one!");
        break;
    default:
        Console.WriteLine("You gave me something else, I guess...");
        break;
}

// Expression form
var response = number switch
{
    0 => "ZERO",
    1 => "ONE",
    _ => "OTHER"
};

Console.WriteLine(response);