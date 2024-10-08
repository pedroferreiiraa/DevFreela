using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.ProjectsQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
{
    
}