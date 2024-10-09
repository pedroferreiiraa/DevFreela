using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.ProjectsQueries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectsDetailsViewModel>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}