using DevFreela.Application.Models;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.UsersCommands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly DevFreelaDbContext _context;
    private readonly IAuthService _authService;
    public InsertUserHandler(DevFreelaDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        var user = request.ToEntity(passwordHash);
        
        await _context.Users.AddAsync(user, cancellationToken);
        
        
        await _context.SaveChangesAsync(cancellationToken);

        
        return ResultViewModel<int>.Success(user.Id);
    }
    
}