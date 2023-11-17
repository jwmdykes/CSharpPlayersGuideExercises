Console.WriteLine("What would you like the password of the door to start as?");
string? password = null;
while (password == null)
{
    password = Console.ReadLine();
}

Door door = new(password);
int command;
string? message = null;

do
{
    Console.Clear();
    
    if (message != null)
    {
        Console.WriteLine(message);
    }
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("----------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"The door is currently {door.State.ToString().ToLower()}.");
    Console.WriteLine("What would you like to do?");

    Console.WriteLine("1. Open the door");
    Console.WriteLine("2. Close the door");
    Console.WriteLine("3. Lock the door");
    Console.WriteLine("4. Unlock the door");
    Console.WriteLine("5. Change the password");
    Console.WriteLine("6. Quit");

    command = Convert.ToInt32(Console.ReadLine());

    switch (command)
    {
        case 1:
            message = door.Open();
            break;
        case 2:
            message = door.Close();
            break;
        case 3:
            message = door.Lock();
            break;
        case 4:
            Console.WriteLine("Enter the password to unlock the door.");
            password = Console.ReadLine()!;
            message = door.Unlock(password);
            break;
        case 5:
            Console.WriteLine("Enter the current password to change the password.");
            string currentPassword = Console.ReadLine()!;
            Console.WriteLine("Enter the new password");
            string newPassword = Console.ReadLine()!;
            message = door.ChangePassword(currentPassword, newPassword);
            break;
        case 6:
            break;
    }
} while (command != 6);

internal class Door
{
    public enum StateEnum
    {
        Open = 0,
        Closed = 1,
        Locked = 2
    }

    private string? _password;

    public Door(string? password)
    {
        _password = password;
        State = StateEnum.Open;
    }

    public StateEnum State { get; private set; }

    public string ChangePassword(string oldPassword, string? newPassword)
    {
        if (oldPassword != _password)
        {
            return "The provided password does not match the current password.";
        }

        _password = newPassword;
        return "Password changed successfully.";
    }

    public string Unlock(string password)
    {
        switch (State)
        {
            case StateEnum.Closed:
            case StateEnum.Open:
                return "Door is already unlocked.";
            case StateEnum.Locked:
                if (password == _password)
                {
                    State = StateEnum.Closed;
                    return "Unlocking the door.";
                }
                else
                {
                    return "Incorrect password.";
                }
        }

        // This line should not be reachable, but it's here to satisfy the compiler.
        return "Unknown error.";
    }

    public string Close()
    {
        switch (State)
        {
            case StateEnum.Locked:
            case StateEnum.Closed:
                return "Door is already closed.";
            case StateEnum.Open:
                State = StateEnum.Closed;
                return "Closing the door.";
        }
        
        // This line should not be reachable, but it's here to satisfy the compiler.
        return "Unknown error.";
    }

    public string Open()
    {
        switch (State)
        {
            case StateEnum.Open:
                return "Door is already open.";
            case StateEnum.Closed:
                State = StateEnum.Open;
                return "Opening the door.";
            case StateEnum.Locked:
                return "The door is locked.";
        }

        // This line should not be reachable, but it's here to satisfy the compiler.
        return "Unknown error.";
    }

    public string Lock()
    {
        switch (State)
        {
            case StateEnum.Open:
                return "Need to close the door before you lock it.";
            case StateEnum.Locked:
                return "The door is already locked.";
            case StateEnum.Closed:
                State = StateEnum.Locked;
                return "Locking the door.";
        }

        // This line should not be reachable, but it's here to satisfy the compiler.
        return "Unknown error.";
    }
}
