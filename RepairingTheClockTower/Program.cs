Console.WriteLine("Input a number from the console");
var num = Convert.ToInt32(Console.ReadLine());

var isEven = num % 2 == 0;

if (isEven)
{
    Console.WriteLine("Tick");
}
else
{
    Console.WriteLine("Tock");
}