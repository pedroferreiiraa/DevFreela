using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;


namespace DevFreela.Application.UsersCommands;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public InsertUserCommand(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }

    // Método para converter o comando em uma entidade User
    public User ToEntity()
        => new User(FullName, Email, BirthDate);
}