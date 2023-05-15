namespace UserAPI.Models;
public class User
{
    internal int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedUserDate { get; set; }

    public User(string? name, string? email, string? birthDate)
    {
        Id = Id;
        Name = name;
        Email = email;
        BirthDate = DateTime.Parse(birthDate!);
        CreatedUserDate = DateTime.Now;
    }

    public User(int id, string? name, string? email, string? birthDate)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = DateTime.Parse(birthDate!);
        CreatedUserDate = DateTime.Now;
    }
}