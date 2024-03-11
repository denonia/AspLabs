namespace Lab6.Models;

public class User
{
    public User(string address, string phoneNumber)
    {
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}