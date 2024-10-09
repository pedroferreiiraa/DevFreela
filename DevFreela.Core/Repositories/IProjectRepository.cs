using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<Project> GetDetailsByIdAsync(int id);
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetDetailsById(int id);
    Task<Project?> GetById(int id);
    Task<int> Add(Project project);
    Task Update(Project project);
    Task AddComment(ProjectComment comment);
    Task<bool> Exists(int id);
}