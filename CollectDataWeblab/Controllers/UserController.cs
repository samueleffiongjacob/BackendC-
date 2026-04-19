using CollectDataWeblab.Model;
using CollectDataWeblab.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollectDataWeblab.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyList<User>> GetUsers()
    {
        return Ok(userService.GetAll());
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        var createdUser = userService.Add(user);
        return Ok(createdUser);
    }
}
