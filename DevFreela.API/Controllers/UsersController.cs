﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    // POST api/users
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
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