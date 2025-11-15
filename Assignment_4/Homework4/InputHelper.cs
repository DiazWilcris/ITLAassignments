public static class InputHelper
{
    public static string GetValidName()
    {
        Console.Write("Name: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (InputValidator.ValidateName(input))
                return input.Trim();
            Console.Write("Valid name required (minimum 2 characters). Try again: ");
        }
    }

    public static string GetValidLastName()
    {
        Console.Write("Last name: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (InputValidator.ValidateName(input))
                return input.Trim();
            Console.Write("Valid last name required (minimum 2 characters). Try again: ");
        }
    }

    public static string GetValidAddress()
    {
        Console.Write("Address: ");
        while (true)
        {
            string address = Console.ReadLine();
            if (InputValidator.ValidateAddress(address))
                return address.Trim();
            Console.Write("Valid Address required (minimum 5 characters). Try again: ");
        }
    }

    public static string GetValidPhone()
    {
        Console.Write("Phone number: ");
        while (true)
        {
            string phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
            {
                Console.Write("Phone number is required. Try again: ");
                continue;
            }

            if (InputValidator.ValidatePhone(phone))
                return phone;

            Console.Write("Invalid phone format. Only numbers and + - ( ) space are allowed. Try again: ");
        }
    }

    public static string GetValidEmail()
    {
        Console.Write("Email: ");
        while (true)
        {
            string email = Console.ReadLine();
            if (InputValidator.ValidateEmail(email))
                return email;
            Console.Write("Invalid Email format. Try again: ");
        }
    }

    public static int GetValidAge()
    {
        Console.Write("Age: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int age) && InputValidator.ValidateAge(age))
                return age;
            Console.Write("Valid age range is (1-120). Try again: ");
        }
    }

    public static int GetContactId(string message)
    {
        Console.Write(message);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int id))
                return id;
            Console.Write("Invalid ID. Try again: ");
        }
    }

    public static byte GetMenuChoice()
    {
        while (true)
        {
            if (!byte.TryParse(Console.ReadLine(), out byte choice))
            {
                Console.Write("Please enter a number: ");
                continue;
            }
            return choice;
        }
    }

    public static void WaitForContinue()
    {
        Console.Write("\nPress enter to continue...");
        Console.ReadLine();
    }

    public static string GetSearchOption()
    {
        while (true)
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Phone");
            Console.WriteLine("3. Email");
            Console.Write("Choose: ");
            string option = Console.ReadLine();

            if (option == "1" || option == "2" || option == "3")
                return option;
            Console.WriteLine("Invalid option. Try again.\n");
        }
    }
}