using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.UserQueries.GetUserById;

public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public GetUserByIdQuery(int id, int idSkill)
    {
        
        Id = id;
        IdSkill = idSkill;
    }

    public int Id { get; set; }
    public int IdSkill { get; set; }
}