Console.Title = "Defense of Consolas";

Console.Write("Target Row? ");
var row = Convert.ToInt32(Console.ReadLine());

Console.Write("Target Column? ");
var col = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Deploy to:");

var top = (row+1, col);
var right = (row, col + 1);
var bottom = (row-1, col);
var left = (row, col-1);

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine(top);
Console.WriteLine(right);
Console.WriteLine(bottom);
Console.WriteLine(left);

Console.Beep();
