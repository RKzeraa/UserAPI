using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IEnumerable<UserViewModel> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50) =>
        UserService.GetAll().Skip(skip).Take(take);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var User = UserService.GetUserById(id);
        if (User == null) return NotFound();

        return Ok(User);
    }

    [HttpGet("GetByName")]
    public IActionResult GetByName([FromQuery] string name)
    {
        var User = UserService.GetUserByName(name);
        if (User.Count < 1) return NotFound();

        return Ok(User);
    }

    [HttpGet("GetByBirthDate")]
    public IActionResult GetByBirthDate([FromQuery] string birthDate)
    {
        // birthDate = birthDate.Replace("%2F", "/");
        var User = UserService.GetUserByBirthDate(birthDate);
        if (User.Count < 1) return NotFound();

        return Ok(User);
    }

    [HttpGet("GetByOlderAge")]
    public IActionResult GetByOlderAge()
    {
        var User = UserService.GetUserByOlderAge();
        if (User == null) return NotFound();

        return Ok(User);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserViewModel userView)
    {
        User? user = UserService.Add(userView);
        return CreatedAtAction(nameof(GetById), new { id = user!.Id }, user.ToString());
    }

    [HttpPut("GetUserById/{id}")]
    public IActionResult Update(int id, [FromBody] UserViewModel userView)
    {
        User? User = UserService.GetUserById(id);
        if (User is null) return NotFound();

        UserService.Update(User, userView);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var User = UserService.GetUserById(id);
        if (User is null) return NotFound();

        UserService.RemoveUser(User);
        return NoContent();
    }
}