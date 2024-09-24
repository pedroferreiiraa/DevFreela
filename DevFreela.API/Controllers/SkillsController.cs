using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillsController : ControllerBase
{
    // GET api/skills
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    // POST api/skills
    [HttpPost]
    public IActionResult Post(CreateSkillInputModel model)
    {
        return Ok();
    }
    
}