namespace Zero.Domain
{
    /// <summary>
    /// Define an interface representes the DDD Entity, has a property named Id, which is generic type.
    /// </summary>
    /// <typeparam name="TKey">The type of the Id</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Identity the entity object.
        /// </summary>
        TKey Id { get; set; }
    }
}
