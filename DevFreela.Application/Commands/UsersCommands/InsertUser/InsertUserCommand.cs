using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.UsersCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public InsertUserCommand(string fullName, string email, DateTime birthDate, string password, string role)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Password = password;
        Role = role;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Role { get; private set; }
    
    public User ToEntity(string passwordHash)
        => new User(FullName, Email, BirthDate, passwordHash, Role);
}