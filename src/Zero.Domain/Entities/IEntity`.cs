namespace Zero.Domain.Entities
{
    /// <summary>
    /// Define an interface representes the DDD Entity, has a property named Id, which is generic type.
    /// </summary>
    /// <typeparam name="TKey">The type of primary key.</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Identity the entity object.
        /// </summary>
        TKey Id { get; set; }
    }
}
