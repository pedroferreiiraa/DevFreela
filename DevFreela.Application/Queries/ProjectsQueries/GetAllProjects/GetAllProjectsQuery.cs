using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.ProjectsQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{
    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}