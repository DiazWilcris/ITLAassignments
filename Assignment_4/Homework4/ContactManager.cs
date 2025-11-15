public class ContactManager
{
    private List<Contact> contacts;
    private int nextId;

    public ContactManager()
    {
        contacts = new List<Contact>();
        nextId = 1;
    }

    public void AddContact(string name, string lastName, string address, string phone, string email, int age, bool isBestFriend)
    {
        var contact = new Contact(nextId++, name, lastName, address, phone, email, age, isBestFriend);
        contacts.Add(contact);
    }

    public List<Contact> GetAllContacts()
    {
        return new List<Contact>(contacts);
    }

    public List<Contact> SearchByName(string name)
    {
        return contacts.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
    }

    public List<Contact> SearchByPhone(string phone)
    {
        return contacts.Where(c => c.Phone.Contains(phone)).ToList();
    }

    public List<Contact> SearchByEmail(string email)
    {
        return contacts.Where(c => c.Email.ToLower().Contains(email.ToLower())).ToList();
    }

    public Contact GetContactById(int id)
    {
        return contacts.FirstOrDefault(c => c.Id == id);
    }

    public bool UpdateContact(int id, string name, string lastName, string address, string phone, string email, int age, bool isBestFriend)
    {
        var contact = GetContactById(id);
        if (contact != null)
        {
            contact.Name = name;
            contact.LastName = lastName;
            contact.Address = address;
            contact.Phone = phone;
            contact.Email = email;
            contact.Age = age;
            contact.IsBestFriend = isBestFriend;
            return true;
        }
        return false;
    }

    public bool DeleteContact(int id)
    {
        var contact = GetContactById(id);
        if (contact != null)
        {
            contacts.Remove(contact);
            return true;
        }
        return false;
    }

    public bool ContactExists(int id)
    {
        return contacts.Any(c => c.Id == id);
    }
}