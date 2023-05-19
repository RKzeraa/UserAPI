using UserAPI.Models;

namespace UserAPI.Services;

public static class UserService
{
    private static int id = 0;

    private static List<User> _users = new List<User>
    {
        new User (id++, "User1", "user1@gmail.com", DateTime.Parse("15/05/2000")),
        new User (id++, "User2", "user2@gmail.com", DateTime.Parse("13/03/1993"))
    };

    public static List<User> GetAll() => _users;

    public static User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public static User? GetUserByName(string name) => _users.Find(u => u.Name!.ToLower() == name.ToLower());

    public static User? GetUserByBirthDate(string birthDate) {
        return _users.Find(u => u.BirthDate.ToString("d").ToLower() == birthDate.ToLower());
    }    

    public static User? Add(UserViewModel userView)
    {
        User user = new User (_users.Count, userView.Name, userView.Email, DateTime.Parse(userView.BirthDate!));
        user.CreatedUserDate = DateTime.Now;
        _users.Add(user);
        return user;
    }

    public static void RemoveUser(User user)
    {
        _users.Remove(user);
    }

    public static void Update(User user, UserViewModel userView)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        if (index == -1)
            return;

        user.CreatedUserDate = DateTime.Now;
        user.Name = userView.Name;
        user.Email = userView.Email;
        user.BirthDate = DateTime.Parse(userView.BirthDate!);
    }
}