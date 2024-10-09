using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.UserQueries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly DevFreelaDbContext _context;
    public GetAllUsersHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Where(u => !u.IsDeleted).ToListAsync();
        
        var model = users.Select(UserViewModel.FromEntity).ToList();

        return new ResultViewModel<List<UserViewModel>>(model);
    }
}

