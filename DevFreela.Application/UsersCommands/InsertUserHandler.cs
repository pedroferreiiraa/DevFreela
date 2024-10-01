using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.UsersCommands;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel>
{
    private readonly DevFreelaDbContext _context;
    public InsertUserHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _context.Users.ToListAsync();
        
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
        
        return ResultViewModel<int>.Success(user);
    }
}