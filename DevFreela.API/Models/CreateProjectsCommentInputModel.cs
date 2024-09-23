namespace DevFreela.API.Models;

public class CreateProjectsCommentInputModel
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}