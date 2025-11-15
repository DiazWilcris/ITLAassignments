public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsBestFriend { get; set; }

    public Contact(int id, string name, string lastName, string address, string phone, string email, int age, bool isBestFriend)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Address = address;
        Phone = phone;
        Email = email;
        Age = age;
        IsBestFriend = isBestFriend;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"\nID: {Id}");
        Console.WriteLine($"Name: {Name} {LastName}");
        Console.WriteLine($"Phone: {Phone}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Best friend: {(IsBestFriend ? "Yes" : "No")}");
        Console.WriteLine("---");
    }
}