using UserAPI.Models;

namespace UserAPI.Services;

public static class UserService
{
    static List<User> Users { get; }
    static int nextId = 3;

    static UserService()
    {
        Users = new List<User>
        {
            new User ( 1, "User1", "user1@gmail.com", "15/05/2000" ),
            new User  ( 2, "User2", "user2@gmail.com", "13/03/1993" )
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(u => u.Id == id);

    public static void Add(User user)
    {
        user.Id = nextId++;
        Users.Add(user);
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if(user is null)
            return;
        
        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);
        if(index == -1)
            return;

        Users[index] = user;
    }
}