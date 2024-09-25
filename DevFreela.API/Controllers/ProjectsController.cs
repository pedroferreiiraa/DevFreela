using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]

public class ProjectsController : ControllerBase
{

    private readonly DevFreelaDbContext _context;
        
    public ProjectsController(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    // private readonly FreelanceTotalCostConfig _config;
    // private readonly IConfigService _configService;
    
    // public ProjectsController(IOptions<FreelanceTotalCostConfig> options,
    //     IConfigService configService)
    // {
    //     _config = options.Value;
    //     _configService = configService;
    //     
    //     
    // }
    
    // GET api/projects?search=crm
    [HttpGet]
    public IActionResult Get(string search = "")
    {
        // return Ok(_configService.GetValue());
        return Ok();
    }
    
    //GET api/projects/1234
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
       
        return Ok();
    }
    
    // POST api/projects
    [HttpPost]
    public IActionResult Post(CreateProjectsInputModel model)
    {
        
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }
    
    // PUT api/projects/1234
    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateProjectsInputModel model)
    {
        return NoContent();
    }
    
    // DELETE api/projects/1234
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
    
    // PUT api/projects/1234/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        return NoContent();
    }
    
    // PUT api/projects/1234/complete
    [HttpPut("{id}/complete")]
    public IActionResult Complete(int id)
    {
        return NoContent();
    }
    
    // POST api/projects/1234/comments
    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, CreateProjectsCommentInputModel model)
    {
        return Ok();
    }

    [HttpPut("{id}/profile-picture")]
    public IActionResult PostProfilePicture(IFormFile file)
    {
        var description = $"File: {file.FileName}, Size: {file.Length}";
        
        // Processar a imagem
        
        return Ok(description);
    }
    
}