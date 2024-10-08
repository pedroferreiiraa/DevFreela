using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectsCommandHandlerTests
{
    [Fact]
    public void ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
    {
        // Arrange
        var projects = new List<Project>
        {
            new Project("Projeto 1", "Dev Freela 1", 1, 2, 100000),
            new Project("Projeto 2", "Dev Freela 2", 1, 2, 200000),
            new Project("Projeto 3", "Dev Freela 3", 1, 2, 300000),

        };
        // Act

        var projectRepository = Substitute.For<IProjectRepository>();

        // Assert
    }
    
}