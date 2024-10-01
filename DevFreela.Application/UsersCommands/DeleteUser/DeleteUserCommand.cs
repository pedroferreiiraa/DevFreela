using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.UsersCommands;

public class DeleteUserCommand : IRequest<ResultViewModel>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}