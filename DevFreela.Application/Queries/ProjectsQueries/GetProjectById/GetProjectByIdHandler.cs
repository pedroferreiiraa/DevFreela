using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.ProjectsQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectsDetailsViewModel>
{
    private readonly IProjectRepository _projectRepository;
    public GetProjectByIdHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<ProjectsDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetDetailsByIdAsync(request.Id);
        
        if (project == null) return null;

        var projectDetailsViewModel = new ProjectsDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.FullName,
            project.Freelancer.FullName
        );
            
            
        
        return projectDetailsViewModel;
    }
}