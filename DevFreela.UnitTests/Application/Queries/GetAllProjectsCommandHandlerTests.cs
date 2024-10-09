using DevFreela.Application.Models;
using DevFreela.Application.Queries.ProjectsQueries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectsCommandHandlerTests
{
    [Fact]
    public async void ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
    {
        // Arrange
        var projects = new List<Project>
        {
            new Project("Projeto 1", "Dev Freela 1", 1, 2, 100000),
            new Project("Projeto 2", "Dev Freela 2", 1, 2, 200000),
            new Project("Projeto 3", "Dev Freela 3", 1, 2, 300000),

        };
        
        var projectRepositoryMock = Substitute.For<IProjectRepository>();
        projectRepositoryMock.GetAllAsync().Returns(projects);

        var getAllProjectsQuery = new GetAllProjectsQuery("");
        var getAllProjectsHandler = new GetAllProjectsHandler(projectRepositoryMock);
        
        // Act
        var projectViewModelList = await getAllProjectsHandler.Handle(getAllProjectsQuery, new CancellationToken());
        
        // Assert
        Assert.NotNull(projectViewModelList);
        Assert.NotEmpty(projectViewModelList);
        Assert.Equal(projects.Count, projectViewModelList.Count);
        
        await projectRepositoryMock.Received(1).GetAllAsync();
    }
    
}