namespace BloodBank.Core.Entities;

public abstract class BaseEntity
{
    //construtor vazio para uso do EF Core quando for rodar as migrations
    protected BaseEntity()
    {

    }

    //usamos o protected para que assim seja possível acessar estas propriedades das classes derivadas
    public int Id { get; protected set; }
    public bool IsActive { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

}
