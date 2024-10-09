using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.UserQueries.GetUserById;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public GetUserByIdQuery(int id, int idSkill)
    {
        
        Id = id;
        IdSkill = idSkill;
    }

    public int Id { get; set; }
    public int IdSkill { get; set; }
}