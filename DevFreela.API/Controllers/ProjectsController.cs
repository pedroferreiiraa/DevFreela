using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        var projects = _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search) )).ToList();

        var model = projects.Select(p =>  ProjectItemViewModel.FromEntity(p)).ToList();
        
        // return Ok(_configService.GetValue());
        return Ok(model);
    }
    
    //GET api/projects/1234
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

        if (project != null)
        {
            var model = ProjectItemViewModel.FromEntity(project);
        
            return Ok(model);
        }

        return Ok();
    }
    
    // POST api/projects
    [HttpPost]
    public IActionResult Post(CreateProjectsInputModel model)
    {
        var project = model.ToEntity();
        
        _context.Projects.Add(project);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }
    
    // PUT api/projects/1234
    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateProjectsInputModel model)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
        {
            return NotFound();
        }

        project.Update(model.Title, model.Description, model.TotalCost);
        
        _context.Projects.Update(project);
        _context.SaveChanges();
        return NoContent();
    }
    
    // DELETE api/projects/1234
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
        {
            return NotFound();
        }
        project.SetAsDeleted();
        _context.Projects.Update(project);
        _context.SaveChanges();
        
        return NoContent();
    }
    
    // PUT api/projects/1234/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
        {
            return NotFound();
        }
        
        project.Start();
        _context.Projects.Update(project);
        _context.SaveChanges();
        
        return NoContent();
    }
    
    // PUT api/projects/1234/complete
    [HttpPut("{id}/complete")]
    public IActionResult Complete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
        {
            return NotFound();
        }
        
        project.Complete();
        _context.Projects.Update(project);
        _context.SaveChanges();
        
        return NoContent();
    }
    
    // POST api/projects/1234/comments
    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, CreateProjectsCommentInputModel model)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
        {
            return NotFound();
        }
        
        var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
        
       _context.ProjectComments.Add(comment);
       _context.SaveChanges();
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