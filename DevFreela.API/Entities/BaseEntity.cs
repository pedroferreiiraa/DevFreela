namespace DevFreela.API.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }
    
    
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
    
}