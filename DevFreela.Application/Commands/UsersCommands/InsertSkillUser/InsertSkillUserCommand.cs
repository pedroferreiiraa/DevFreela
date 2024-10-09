using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UsersCommands.InsertSkillUser;

public class InsertSkillUserCommand : IRequest<ResultViewModel>
{
    public InsertSkillUserCommand(int skillId)
    {
        SkillId = skillId;
    }

    public int SkillId { get; set; }
}