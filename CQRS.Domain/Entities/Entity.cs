namespace CQRS.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}