using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.UsersCommands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly DevFreelaDbContext _context;
    
    public DeleteUserHandler (DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);
        
        if (user is null)
        {
            return ResultViewModel.Error("User not found");
        }
        
        user.SetAsDeleted();
        _context.Users.Remove(user);
        _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}