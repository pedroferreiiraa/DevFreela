
using DevFreela.Application.UserQueries;
using DevFreela.Application.UserQueries.GetAllUsers;
using DevFreela.Application.UserQueries.GetUserById;
using DevFreela.Application.UsersCommands;
using DevFreela.Application.UsersCommands.DeleteUser;
using DevFreela.Application.UsersCommands.InsertSkillUser;
using DevFreela.Application.UsersCommands.InsertUser;
using DevFreela.Application.UsersCommands.LoginUser;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        
        
        private readonly IMediator _mediator;
        
        public UsersController(DevFreelaDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async  Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllUsersQuery();
            
            var result = await _mediator.Send(query);
            
            
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, int idSkill)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id, idSkill));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        
        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(InsertSkillUserCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem

            return Ok(description);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
            {
                return BadRequest();
            }
            
            return Ok(loginUserViewModel);
        }
    }
}