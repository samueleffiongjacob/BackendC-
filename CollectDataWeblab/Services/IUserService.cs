using CollectDataWeblab.Model;

namespace CollectDataWeblab.Services;

public interface IUserService
{
    IReadOnlyList<User> GetAll();
    User Add(User user);
}
