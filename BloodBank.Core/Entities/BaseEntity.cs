namespace BloodBank.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = null;
    }

    public int Id { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; protected set; }

    public void Inactive()
    {
        if(IsActive == true)
            IsActive = false;
    }
}
