using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    // POST api/users
    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
}