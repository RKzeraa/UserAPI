using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models;
public class User
{
    internal int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    internal DateTime CreatedUserDate { get; set; }

    public User ()
    {
    }

    public User(int id, string? name, string? email, DateTime birthDate)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate!;
        CreatedUserDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, Birthdate: {BirthDate.ToString("d")}";
    }
}