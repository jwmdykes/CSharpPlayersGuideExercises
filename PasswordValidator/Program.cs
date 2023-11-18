Console.Write("Pick a password for me to validate:  ");
string password = Console.ReadLine()!;
var results = PasswordValidator.Validate(password);

while (true)
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("----------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
        
    Console.WriteLine(results.Status);
    
    Console.Write("Pick another password    ");
    password = Console.ReadLine()!;
    results = PasswordValidator.Validate(password);
}


internal class PasswordValidation
{
    public override string ToString() => $"Password is {(Succeeded ? "valid" : "invalid")}";
    
    public static readonly PasswordValidation IncorrectLength = new()
        { Succeeded = false, Status = "Password must be between 6 and 13 characters" };

    public static readonly PasswordValidation InvalidCharacter = new()
    {
        Succeeded = false, Status = "Password must not include '&' or 'T'"
    };

    public static readonly PasswordValidation MissingRequiredCharacters = new()
    {
        Succeeded = false, Status = "Password must contain at least one uppercase, one lowercase, and one number."
    };

    public static readonly PasswordValidation Success = new()
    {
        Succeeded = true, Status = "Password is valid."
    };
    
    public bool Succeeded { get; set; }
    public string Status { get; set; } = "";
}

internal class PasswordValidator
{
    public static PasswordValidation Validate(string password)
    {
        if (password.Length < 6 || password.Length > 13)
        {
            return PasswordValidation.IncorrectLength;
        }

        
        var containsUpper = false;
        var containsLower = false;
        var containsNumber = false;
        foreach (char c in password)
        {
            if (c == '&' || c == 'T')
                return PasswordValidation.InvalidCharacter;
            else if (char.IsUpper(c))
                containsUpper = true;
            else if (char.IsLower(c))
                containsLower = true;
            else if (char.IsDigit(c))
                containsNumber = true;
        }
        
        if (!containsLower || ! containsNumber || !containsUpper)
            return PasswordValidation.MissingRequiredCharacters;


        return PasswordValidation.Success;
    }

}