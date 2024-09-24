namespace DevFreela.API.Entities;

public class UserSkill : BaseEntity
{
    public UserSkill(int idUser, int idSkill) : base()
    {
        IdUser = idUser;
        IdSkill = idSkill;
    }

    public int IdUser { get; set; }
    public User User { get; set; }
    
    public int IdSkill { get; set; }
    public Skill Skill { get; set; }
}