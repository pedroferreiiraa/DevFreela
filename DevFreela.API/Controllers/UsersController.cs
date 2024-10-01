﻿
using DevFreela.Application.UserQueries;
using DevFreela.Application.UserQueries.GetUserById;
using DevFreela.Application.UsersCommands;
using DevFreela.Application.UsersCommands.InsertSkillUser;

using DevFreela.Infrastructure.Persistence;
using MediatR;
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
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

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
            // var result = _service.Insert(model);

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
    }
}