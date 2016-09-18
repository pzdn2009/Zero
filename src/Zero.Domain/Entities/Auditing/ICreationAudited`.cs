namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// The interface provides creation audit for an entity
    /// ,with a creation user id as an optional field.
    /// </summary>
    /// <typeparam name="TKey">The type of primary key.</typeparam>
    public interface ICreationAudited<TKey> : ICreationTime where TKey : struct
    {
        /// <summary>
        ///  The id of the user who created the entity.
        /// </summary>
        TKey? CreationUserId { get; set; }
    }
}
