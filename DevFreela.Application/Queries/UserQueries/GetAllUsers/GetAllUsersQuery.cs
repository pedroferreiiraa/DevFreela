using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.UserQueries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
    
}