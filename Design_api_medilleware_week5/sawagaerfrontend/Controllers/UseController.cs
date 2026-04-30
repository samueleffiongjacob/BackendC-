using Microsoft.AspNetCore.Mvc;
using System.Linq;

// Simple response model used by the test endpoints.
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class UseController : ControllerBase
{
    // In-memory test data for read endpoint demos.
    private static readonly List<User> Users =
    [
        new User { Id = 1, Name = "User1", Email = "user1@example.com" },
        new User { Id = 2, Name = "User2", Email = "user2@example.com" },
        new User { Id = 3, Name = "User3", Email = "user3@example.com" }
    ];

    [HttpGet]
    [Produces("application/json")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(Users);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<User> GetUser(int id)
    {
        var user = Users.FirstOrDefault(currentUser => currentUser.Id == id);

        if (user is null)
        {
            return NotFound(new { message = $"User with id {id} was not found." });
        }

        return Ok(user);
    }

    [HttpGet("by-email/{email}")]
    [Produces("application/json")]
    public ActionResult<User> GetUserByEmail(string email)
    {
        var user = Users.FirstOrDefault(currentUser =>
            string.Equals(currentUser.Email, email, StringComparison.OrdinalIgnoreCase));

        if (user is null)
        {
            return NotFound(new { message = $"User with email '{email}' was not found." });
        }

        return Ok(user);
    }

    [HttpGet("summary")]
    [Produces("application/json")]
    public ActionResult<object> GetSummary()
    {
        // Quick health-style payload to validate API responses during testing.
        return Ok(new
        {
            TotalUsers = Users.Count,
            TimestampUtc = DateTime.UtcNow
        });
    }

}