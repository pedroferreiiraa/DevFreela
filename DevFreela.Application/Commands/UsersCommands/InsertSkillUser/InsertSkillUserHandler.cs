using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UsersCommands.InsertSkillUser;

public class InsertSkillUserHandler : IRequestHandler<InsertSkillUserCommand, ResultViewModel>
{
    private readonly DevFreelaDbContext _context;
    
    public InsertSkillUserHandler (DevFreelaDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(InsertSkillUserCommand request, CancellationToken cancellationToken)
    {
        
        
        var skill = await _context.Skills.SingleOrDefaultAsync(s => s.Id == request.SkillId);

        // Verificar se a skill existe
        if (skill == null)
        {
            return ResultViewModel.Error("Skill not found");
        }

        // Verificar se o usuário já possui essa skill
        var userSkillExists = await _context.UserSkills
            .AnyAsync(us => us.IdUser == request.SkillId && us.IdUser == request.SkillId);

        if (userSkillExists)
        {
            return ResultViewModel.Error("User already has this skill");
        }

        // Se não existir, criar a associação entre o usuário e a skill
        await _context.SaveChangesAsync();   // Salvar as mudanças no banco de dados

        return ResultViewModel.Success();  // Retornar sucesso
    }
}