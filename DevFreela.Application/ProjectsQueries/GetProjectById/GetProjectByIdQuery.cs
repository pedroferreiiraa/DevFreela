using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.ProjectsQueries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ResultViewModel<ProjectViewModel>>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}