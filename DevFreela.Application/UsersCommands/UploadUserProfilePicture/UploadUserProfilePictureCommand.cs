namespace DevFreela.Application.UsersCommands.UploadUserProfilePicture;

public class UploadUserProfilePictureCommand
{
    
    public int UserId { get; set; }
    public IFormFile File { get; set; }
}