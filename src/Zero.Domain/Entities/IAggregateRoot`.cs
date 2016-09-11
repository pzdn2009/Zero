namespace Zero.Domain.Entities
{
    /// <summary>
    /// Used to identify the aggregate-root of an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
    }
}
