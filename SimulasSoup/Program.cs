Console.WriteLine("Pick a food:");

Console.WriteLine("1. Soup");
Console.WriteLine("2. Stew");
Console.WriteLine("3. Gumbo");
int foodNum = GetNumberBetween(1, 3);

Console.WriteLine("\nPick a main ingredient:");
Console.WriteLine("1. Mushrooms");
Console.WriteLine("2. Chicken");
Console.WriteLine("3. Carrots");
Console.WriteLine("4. Potatoes");
int ingredientNum = GetNumberBetween(1, 4);

Console.WriteLine("\nPick a seasoning:");
Console.WriteLine("1. Spicy");
Console.WriteLine("2. Salty");
Console.WriteLine("3. Sweet");
int seasoningNum = GetNumberBetween(1, 3);

(Food food, MainIngredient mainIngredient, Seasoning seasoning) soup = (foodNum switch
        {
            1 => Food.Soup,
            2 => Food.Stew,
            3 => Food.Gumbo
        },
        ingredientNum switch
        {
            1 => MainIngredient.Mushrooms,
            2 => MainIngredient.Chicken,
            3 => MainIngredient.Carrots,
            4 => MainIngredient.Potatoes
        },
        seasoningNum switch
        {
            1 => Seasoning.Spicy,
            2 => Seasoning.Salty,
            3 => Seasoning.Sweet
        }
    );

Console.WriteLine($"Your soup is a {soup.seasoning} {soup.mainIngredient} {soup.food}");

return;

int GetNumberBetween(int min, int max)
{
    int num = 0;
    bool valid;

    do
    {
        valid = true;
        try
        {
            num = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            valid = false;
        }

        valid = valid && num >= min && num <= max;
    } while (!valid);

    return num;
}

enum Food
{
    Soup,
    Stew,
    Gumbo
}

enum MainIngredient
{
    Mushrooms,
    Chicken,
    Carrots,
    Potatoes
}

enum Seasoning
{
    Spicy,
    Salty,
    Sweet
}