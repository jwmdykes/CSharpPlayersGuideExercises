using BuyingInventory;

Item[] items =
{
    new ("Rope", 10),
    new ("Torches", 15),
    new ("Climbing Equipment", 25),
    new ("Clean Water", 1),
    new ("Machete", 20),
    new ("Canoe", 200),
    new ("Food Supplies", 1)
};

Console.WriteLine("The following items are available:");

for (var i = 0; i < items.Length; i++)
{
    var item = items[i];
    Console.WriteLine($"{item.Name} - {i+1}");
}

Console.Write("What number do you want to see the price of? ");
var itemNumber = Convert.ToInt32(Console.ReadLine());
itemNumber = Math.Clamp(itemNumber, 0, items.Length - 1);

var selectedItem = items[itemNumber - 1];
Console.WriteLine($"{selectedItem.Name} cost(s) {selectedItem.Price} gold.");