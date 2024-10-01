using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.UserQueries;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
    
}