public class Interface
{
    private ContactManager contactManager;

    public Interface()
    {
        contactManager = new ContactManager();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to my contacts list");
        bool executing = true;

        while (executing)
        {
            ShowMainMenu();
            byte choice = InputHelper.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    ShowAllContacts();
                    break;
                case 3:
                    SearchContact();
                    break;
                case 4:
                    ModifyContact();
                    break;
                case 5:
                    DeleteContact();
                    break;
                case 6:
                    executing = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Are You Stupid or Something!");
                    InputHelper.WaitForContinue();
                    break;
            }
        }
    }

    private void ShowMainMenu()
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
    }

    private void AddContact()
    {
        Console.Clear();
        Console.WriteLine("ADD NEW CONTACT");
        Console.WriteLine("----------------");

        string name = InputHelper.GetValidName();
        string lastName = InputHelper.GetValidLastName();
        string address = InputHelper.GetValidAddress();
        string phone = InputHelper.GetValidPhone();
        string email = InputHelper.GetValidEmail();
        int age = InputHelper.GetValidAge();

        Console.Write("Best friend? (1=Yes, 2=No): ");
        bool isBestFriend = Console.ReadLine() == "1";

        contactManager.AddContact(name, lastName, address, phone, email, age, isBestFriend);
        Console.WriteLine("\nContact added successfully!");
        InputHelper.WaitForContinue();
    }

    private void ShowAllContacts(bool waitForContinue = true)
    {
        Console.Clear();
        Console.WriteLine("CONTACT LIST");
        Console.WriteLine("------------");

        var contacts = contactManager.GetAllContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                contact.DisplayDetails();
            }
        }
        if (waitForContinue)
        {
            InputHelper.WaitForContinue();
        }
    }

    private void SearchContact()
    {
        bool keepSearching = true;

        while (keepSearching)
        {
            Console.Clear();
            Console.WriteLine("SEARCH CONTACT");
            Console.WriteLine("--------------");

            string option = InputHelper.GetSearchOption();
            List<Contact> results = new List<Contact>();

            switch (option)
            {
                case "1":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();
                    results = contactManager.SearchByName(searchName);
                    break;
                case "2":
                    Console.Write("Enter phone to search: ");
                    string searchPhone = Console.ReadLine();
                    results = contactManager.SearchByPhone(searchPhone);
                    break;
                case "3":
                    Console.Write("Enter email to search: ");
                    string searchEmail = Console.ReadLine();
                    results = contactManager.SearchByEmail(searchEmail);
                    break;
            }

            if (results.Count > 0)
            {
                Console.WriteLine($"\nFound {results.Count} contact(s):");
                foreach (var contact in results)
                {
                    contact.DisplayDetails();
                }
            }
            else
            {
                Console.WriteLine("No contacts found.");
            }

            Console.Write("\nDo you want to make another search? (1=Yes, 2=No): ");
            string continueChoice = Console.ReadLine();
            keepSearching = continueChoice == "1";
        }
    }

    private void ModifyContact()
    {
        Console.Clear();
        Console.WriteLine("MODIFY CONTACT");
        Console.WriteLine("--------------");

        var contacts = contactManager.GetAllContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to modify.");
            InputHelper.WaitForContinue();
            return;
        }

        ShowAllContacts(false);
        int id = InputHelper.GetContactId("\nEnter contact ID to modify: ");

        if (!contactManager.ContactExists(id))
        {
            Console.WriteLine("Invalid ID.");
            InputHelper.WaitForContinue();
            return;
        }

        var contact = contactManager.GetContactById(id);
        Console.WriteLine($"\nModifying: {contact.Name} {contact.LastName}");

        ShowModifyMenu();
        string option = Console.ReadLine();

        string newName = contact.Name;
        string newLastName = contact.LastName;
        string newAddress = contact.Address;
        string newPhone = contact.Phone;
        string newEmail = contact.Email;
        int newAge = contact.Age;
        bool newIsBestFriend = contact.IsBestFriend;

        switch (option)
        {
            case "1":
                newName = InputHelper.GetValidName();
                break;
            case "2":
                newLastName = InputHelper.GetValidLastName();
                break;
            case "3":
                newAddress = InputHelper.GetValidAddress();
                break;
            case "4":
                newPhone = InputHelper.GetValidPhone();
                break;
            case "5":
                newEmail = InputHelper.GetValidEmail();
                break;
            case "6":
                newAge = InputHelper.GetValidAge();
                break;
            case "7":
                Console.Write("Best friend? (1=Yes, 2=No): ");
                newIsBestFriend = Console.ReadLine() == "1";
                break;
            default:
                Console.WriteLine("Invalid option.");
                InputHelper.WaitForContinue();
                return;
        }

        if (contactManager.UpdateContact(id, newName, newLastName, newAddress, newPhone, newEmail, newAge, newIsBestFriend))
        {
            Console.WriteLine("Contact modified!");
        }
        else
        {
            Console.WriteLine("Error modifying contact.");
        }
        InputHelper.WaitForContinue();
    }

    private void ShowModifyMenu()
    {
        Console.WriteLine("What to modify?");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Last name");
        Console.WriteLine("3. Address");
        Console.WriteLine("4. Phone");
        Console.WriteLine("5. Email");
        Console.WriteLine("6. Age");
        Console.WriteLine("7. Best friend");
        Console.Write("Choose: ");
    }

    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("DELETE CONTACT");
        Console.WriteLine("--------------");

        var contacts = contactManager.GetAllContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to delete.");
            InputHelper.WaitForContinue();
            return;
        }

        ShowAllContacts(false);
        int id = InputHelper.GetContactId("\nEnter contact ID to delete: ");

        if (!contactManager.ContactExists(id))
        {
            Console.WriteLine("Invalid ID.");
            InputHelper.WaitForContinue();
            return;
        }

        var contact = contactManager.GetContactById(id);
        Console.WriteLine($"Delete {contact.Name} {contact.LastName}? (y/n)");

        if (Console.ReadLine().ToLower() == "y")
        {
            if (contactManager.DeleteContact(id))
            {
                Console.WriteLine("Contact deleted!");
            }
            else
            {
                Console.WriteLine("Error deleting contact.");
            }
        }
        else
        {
            Console.WriteLine("Deletion cancelled.");
        }
        InputHelper.WaitForContinue();
    }
}