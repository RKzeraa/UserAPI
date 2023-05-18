using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IEnumerable<User> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50) =>
        UserService.GetAll().Skip(skip).Take(take);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var User = UserService.GetUserById(id);
        if (User == null) return NotFound();

        return Ok(User);
    }

    [HttpGet("GetByName/{name}")]
    public IActionResult GetByName(string name)
    {
        var User = UserService.GetUserByName(name);
        if (User == null) return NotFound();

        return Ok(User);
    }

    [HttpGet("GetByBirthDate/{birthDate}")]
    public IActionResult GetByBirthDate(string birthDate)
    {
        birthDate = birthDate.Replace("%2F", "/");
        var User = UserService.GetUserByBirthDate(birthDate);
        Console.WriteLine(birthDate);
        if (User == null) return NotFound();

        return Ok(User);
    }


    [HttpPost]
    public IActionResult Create(User user)
    {
        UserService.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToString());
    }

    [HttpPut("GetUserById/{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        var User = UserService.GetUserById(user.Id = id);
        if (User is null) return NotFound();

        UserService.Update(user);
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