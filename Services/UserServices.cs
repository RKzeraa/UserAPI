using UserAPI.Models;

namespace UserAPI.Services;

public static class UserService
{
    private static int id = 0;
    private static List<User> Users = new List<User>
    {
        new User (id++, "User1", "user1@gmail.com", "15/05/2000" ),
        new User (id++, "User2", "user2@gmail.com", "13/03/1993" )
    };

    public static List<User> GetAll() => Users;

    public static User? GetUserById(int id) => Users.FirstOrDefault(u => u.Id == id);

    public static User? GetUserByName(string name) => Users.Find(u => u.Name!.ToLower() == name.ToLower());

    public static User? GetUserByBirthDate(string birthDate) {
        Console.WriteLine(birthDate);
        return Users.Find(u => u.BirthDate!.ToLower() == birthDate.ToLower());
    }    

    public static void Add(User user)
    {
        user.Id = id++;
        user.CreatedUserDate = DateTime.Now;
        Users.Add(user);
    }

    public static void RemoveUser(User user)
    {
        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);
        if (index == -1)
            return;

        Users[index] = user;
    }
}