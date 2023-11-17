Console.WriteLine(@"The following items are available:
Rope - 1
Torches - 2
Climbing Equipment - 3
Clean Water - 4
Machete - 5
Canoe - 6
Food Supplies - 7
");

Console.Write("What number do you want to see the price of? ");
var selection = Convert.ToInt32(Console.ReadLine());

string outputString;
// switch (selection)
// {
//     case 1:
//         outputString = "Rope costs 10 gold";
//         break;
//     case 2:
//         outputString = "Torches cost 15 gold";
//         break;
//     case 3:
//         outputString = "Climbing Equipment costs 25 gold";
//         break;
//     case 4:
//         outputString = "Clean Water costs 1 gold";
//         break;
//     case 5:
//         outputString = "Machete costs 20 gold";
//         break;
//     case 6:
//         outputString = "Canoe costs 200 gold";
//         break;
//     case 7:
//         outputString = "Food Supplies cost 1 gold";
//         break;
//     default:
//         outputString = "Sorry, I don't have such a product";
//         break;
// }

Console.Write("Sorry I forgot to ask what your name is... ");
var name = Console.ReadLine();
var sameAsMyName = name == "John";

outputString = selection switch
{
    1 => $"Rope costs {(sameAsMyName ? 5 : 10)} gold",
    2 => $"Torches cost {(sameAsMyName ? 7.5 : 15)} gold",
    3 => $"Climbing Equipment costs {(sameAsMyName ? 25.0/2 : 25)} gold",
    _ => $"My books all burned up past the third item!"
};

Console.WriteLine(outputString);