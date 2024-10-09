using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UsersCommands.LoginUser;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}