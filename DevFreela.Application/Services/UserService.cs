using DevFreela.Application.Services;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DevFreela.Application.Models;


public class UserService : IUserService
{
    private readonly DevFreelaDbContext _context;

    public UserService(DevFreelaDbContext context)
    {
        _context = context;
    }


    public ResultViewModel<List<UserViewModel>> GetAll(string search = "")
    {
        var usersQuery = _context.Users
            .Include(u => u.Skills) // Corrigido para incluir apenas as habilidades
            .Where(u => !u.IsDeleted);

        // Se houver um termo de busca, aplique um filtro
        if (!string.IsNullOrWhiteSpace(search))
        {
            usersQuery = usersQuery.Where(u => u.FullName.Contains(search)); // Supondo que você queira pesquisar pelo nome
        }

        var model = usersQuery.Select(UserViewModel.FromEntity).ToList();

        return ResultViewModel<List<UserViewModel>>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateUserInputModel model)
    {
        var user = model.ToEntity();
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(user.Id);
    }

    public ResultViewModel<UserViewModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ResultViewModel Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");
        }
        
        user.SetAsDeleted();
        _context.Users.Update(user);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }
}