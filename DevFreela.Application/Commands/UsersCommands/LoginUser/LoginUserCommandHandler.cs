using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.UsersCommands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    
    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        if (user == null)
        {
            return null;
        }
        
        var token = _authService.GenerateJwtToken(user.Email, user.Role);
        
        return new LoginUserViewModel(user.Email, token);
    }
}