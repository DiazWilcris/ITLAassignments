using System.Net.Mail;
Console.WriteLine("Welcome to my contacts list");
byte Choice;
bool executing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> phones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (executing)
{
    Console.Clear();
    Console.WriteLine("CONTACTS MENU");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View Contacts");
    Console.WriteLine("3. Search Contact");
    Console.WriteLine("4. Modify Contact");
    Console.WriteLine("5. Delete Contact");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    while (true)
    {
        if (!byte.TryParse(Console.ReadLine(), out Choice))
        {
            Console.Write("Please enter a number: ");
            continue;
        }
        else
        {
            break;
        }
    }

    switch (Choice)
    {
        case 1:
            Console.Clear();
            AddContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
            WaitForContinue();
            break;
        case 2:
            Console.Clear();
            ShowContacts(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
            WaitForContinue();
            break;
        case 3:
            Console.Clear();
            SearchContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
            WaitForContinue();
            break;
        case 4:
            Console.Clear();
            ModifyContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
            WaitForContinue();
            break;
        case 5:
            Console.Clear();
            DeleteContact(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);
            WaitForContinue();
            break;
        case 6:
            executing = false;
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option!");
            WaitForContinue();
            break;
    }
}

static void WaitForContinue()
{
    Console.Write("\nPress enter to continue...");
    Console.ReadLine();
}

static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("ADD NEW CONTACT");
    Console.WriteLine("----------------");

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Last name: ");
    string lastname = Console.ReadLine();

    Console.Write("Address: ");
    string address = Console.ReadLine();

    Console.Write("Phone number: ");
    string phone;
    while (true)
    {
        phone = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(phone))
        {
            Console.Write("Phone cannot be empty. Try again: ");
            continue;
        }

        bool isValidPhone = true;
        foreach (char c in phone)
        {
            if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ' && c != '(' && c != ')')
            {
                isValidPhone = false;
                break;
            }
        }

        if (isValidPhone)
        {
            break;
        }
        else
        {
            Console.Write("Phone can only contain numbers and +,-,(,). Try again: ");
        }
    }

    Console.Write("Email: ");
    string email;
    while (true)
    {
        email = Console.ReadLine();
        try
        {
            var tempEmail2 = new MailAddress(email);
            email = tempEmail2.Address;
            break;
        }
        catch (FormatException)
        {
            Console.Write("Invalid email format. Please try again: ");
            continue;
        }
    }

    Console.Write("Age: ");
    int age;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Invalid age. Try again: ");
            continue;
        }

        if (age < 1)
        {
            Console.Write("They're not even born yet. Try again: ");
            continue;
        }

        break;
    }

    Console.Write("Best friend? (1=Yes, 2=No): ");
    bool isBestFriend = Console.ReadLine() == "1";

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    phones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

    Console.WriteLine("\nContact added successfully!");
}

static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("CONTACT LIST");
    Console.WriteLine("------------");

    if (ids.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }

    foreach (var id in ids)
    {
        Console.WriteLine($"\nID: {id}");
        Console.WriteLine($"Name: {names[id]} {lastnames[id]}");
        Console.WriteLine($"Phone: {phones[id]}");
        Console.WriteLine($"Email: {emails[id]}");
        Console.WriteLine($"Address: {addresses[id]}");
        Console.WriteLine($"Age: {ages[id]}");
        Console.WriteLine($"Best friend: {(bestFriends[id] ? "Yes" : "No")}");
        Console.WriteLine("---");
    }
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("SEARCH CONTACT");
    Console.WriteLine("--------------");

    string option;
    while (true)
    {
        Console.WriteLine("Search by:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Phone");
        Console.WriteLine("3. Email");
        Console.Write("Choose: ");
        option = Console.ReadLine();

        if (option == "1" || option == "2" || option == "3")
            break;
        Console.WriteLine("Invalid option. Try again.\n");
    }

    bool found = false;

    if (option == "1")
    {
        Console.Write("Enter name to search: ");
        string searchName = Console.ReadLine();

        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(searchName.ToLower()))
            {
                ShowContactDetails(id, names, lastnames, addresses, phones, emails, ages, bestFriends);
                found = true;
            }
        }
    }
    else if (option == "2")
    {
        Console.Write("Enter phone to search: ");
        string searchPhone = Console.ReadLine();

        foreach (var id in ids)
        {
            if (phones[id].Contains(searchPhone))
            {
                ShowContactDetails(id, names, lastnames, addresses, phones, emails, ages, bestFriends);
                found = true;
            }
        }
    }
    else if (option == "3")
    {
        Console.Write("Enter email to search: ");
        string searchEmail = Console.ReadLine();

        foreach (var id in ids)
        {
            if (emails[id].ToLower().Contains(searchEmail.ToLower()))
            {
                ShowContactDetails(id, names, lastnames, addresses, phones, emails, ages, bestFriends);
                found = true;
            }
        }
    }

    if (!found)
        Console.WriteLine("No contacts found.");
}

static void ShowContactDetails(int id, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine($"\nContact found:");
    Console.WriteLine($"Name: {names[id]} {lastnames[id]}");
    Console.WriteLine($"Phone: {phones[id]}");
    Console.WriteLine($"Email: {emails[id]}");
    Console.WriteLine($"Address: {addresses[id]}");
    Console.WriteLine($"Age: {ages[id]}");
    Console.WriteLine($"Best friend: {(bestFriends[id] ? "Yes" : "No")}");
    Console.WriteLine("---");
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("MODIFY CONTACT");
    Console.WriteLine("--------------");

    if (ids.Count == 0)
    {
        Console.WriteLine("No contacts to modify.");
        return;
    }

    ShowContacts(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);

    Console.Write("\nEnter contact ID to modify: ");
    if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    Console.WriteLine($"\nModifying: {names[id]} {lastnames[id]}");
    Console.WriteLine("What to modify?");
    Console.WriteLine("1. Name");
    Console.WriteLine("2. Last name");
    Console.WriteLine("3. Address");
    Console.WriteLine("4. Phone");
    Console.WriteLine("5. Email");
    Console.WriteLine("6. Age");
    Console.WriteLine("7. Best friend");
    Console.Write("Choose: ");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("New name: ");
            names[id] = Console.ReadLine();
            break;
        case "2":
            Console.Write("New last name: ");
            lastnames[id] = Console.ReadLine();
            break;
        case "3":
            Console.Write("New address: ");
            addresses[id] = Console.ReadLine();
            break;
        case "4":
            Console.Write("New phone: ");
            string newPhone;
            while (true)
            {
                newPhone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newPhone))
                {
                    Console.Write("Phone cannot be empty: ");
                    continue;
                }

                bool isValidPhone = true;
                foreach (char c in newPhone)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ' && c != '(' && c != ')')
                    {
                        isValidPhone = false;
                        break;
                    }
                }

                if (isValidPhone)
                {
                    phones[id] = newPhone;
                    break;
                }
                else
                {
                    Console.Write("Invalid phone. Try again: ");
                }
            }
            break;
        case "5":
            Console.Write("New email: ");
            string newEmail;
            while (true)
            {
                newEmail = Console.ReadLine();
                try
                {
                    var tempEmail2 = new MailAddress(newEmail);
                    emails[id] = tempEmail2.Address;
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Invalid email format. Please try again: ");
                    continue;
                }
            }
            break;
        case "6":
            Console.Write("New age: ");
            int newAge;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out newAge))
                {
                    Console.Write("Invalid age. Try again: ");
                    continue;
                }

                if (newAge < 1)
                {
                    Console.Write("They're not even born yet. Try again: ");
                    continue;
                }

                ages[id] = newAge;
                break;
            }
            break;
        case "7":
            Console.Write("Best friend? (1=Yes, 2=No): ");
            bestFriends[id] = Console.ReadLine() == "1";
            break;
        default:
            Console.WriteLine("Invalid option.");
            return;
    }

    Console.WriteLine("Contact modified!");
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("DELETE CONTACT");
    Console.WriteLine("--------------");

    if (ids.Count == 0)
    {
        Console.WriteLine("No contacts to delete.");
        return;
    }

    ShowContacts(ids, names, lastnames, addresses, phones, emails, ages, bestFriends);

    Console.Write("\nEnter contact ID to delete: ");
    if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    Console.WriteLine($"Delete {names[id]} {lastnames[id]}? (y/n)");
    if (Console.ReadLine().ToLower() == "y")
    {
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        phones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);
        Console.WriteLine("Contact deleted!");
    }
    else
    {
        Console.WriteLine("Deletion cancelled.");
    }
}