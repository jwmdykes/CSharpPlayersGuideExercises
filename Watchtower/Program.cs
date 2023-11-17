Console.WriteLine("Input an x and y value");
var x = Convert.ToInt32(Console.ReadLine());
var y = Convert.ToInt32(Console.ReadLine());

var enemyLocation = "";

if (y > 0)
{
    enemyLocation += "north";
}
else if (y < 0)
{
    enemyLocation += "south";
}

if (x > 0)
{
    enemyLocation += "east";
}
else if (x < 0)
{
    enemyLocation += "west";
}

var outputString = enemyLocation == "" ? "The enemy is here!" : $"The enemy is to the {enemyLocation}";

Console.WriteLine(outputString);
