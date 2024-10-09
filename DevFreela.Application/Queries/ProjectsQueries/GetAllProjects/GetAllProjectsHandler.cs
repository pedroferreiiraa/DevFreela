using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.ProjectsQueries.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly IProjectRepository _projectRepository;
    public GetAllProjectsHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects =  await _projectRepository.GetAllAsync();
        
        var projectsViewModel = projects   
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }
}