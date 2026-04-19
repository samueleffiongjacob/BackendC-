using CollectDataWeblab.Model;

namespace CollectDataWeblab.Services;

public class InMemoryUserService : IUserService
{
    private readonly List<User> _users = [];

    public IReadOnlyList<User> GetAll() => _users;

    public User Add(User user)
    {
        _users.Add(user);
        return user;
    }
}
