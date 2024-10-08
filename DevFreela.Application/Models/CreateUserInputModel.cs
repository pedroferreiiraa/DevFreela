using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public class CreateUserInputModel
{
    public string FullName { get;  set; }
    public string Email { get;   set; }
    public string Password { get;  set; }
    public DateTime BirthDate { get;   set; }
    
    public string Role { get;  set; }

    public User ToEntity()
        => new( FullName = FullName, Email = Email, BirthDate = BirthDate, Password = Password, Email = Email );
}