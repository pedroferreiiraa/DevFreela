using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<ResultViewModel>
{
    
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}