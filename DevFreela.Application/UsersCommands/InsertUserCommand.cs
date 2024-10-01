using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.UsersCommands;

public class InsertUserCommand : IRequest<ResultViewModel>
{
    public InsertUserCommand(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }

    public string FullName { get;  set; }
    public string Email { get;   set; }
    public DateTime BirthDate { get;   set; }

    public User ToEntity()
        => new( FullName = FullName, Email = Email, BirthDate = BirthDate );
}