using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.UsersCommands;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly DevFreelaDbContext _context;
    public InsertUserHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        // Cria o objeto User a partir dos dados do comando
        var user = request.ToEntity();

        // Adiciona o novo usuário ao banco de dados
        await _context.Users.AddAsync(user, cancellationToken);
        
        // Salva as mudanças
        await _context.SaveChangesAsync(cancellationToken);

        // Retorna o resultado com o ID do usuário
        return ResultViewModel<int>.Success(user.Id);
    }
    
}