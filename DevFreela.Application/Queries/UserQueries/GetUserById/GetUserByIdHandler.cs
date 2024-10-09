using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.UserQueries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            return null;
        }

        var model = UserViewModel.FromEntity(user);

        return model;

    }
}