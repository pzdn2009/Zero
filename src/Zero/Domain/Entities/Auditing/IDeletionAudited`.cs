using System;

namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// The interface provides deletion audit for an entity.
    /// Of course , only inherit the <see cref="ISoftDelete"/> ,it makes sense.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public interface IDeletionAudited<TKey> : ISoftDelete where TKey : struct
    {
        /// <summary>
        /// The time when deleted.
        /// </summary>
        DateTime? DeletionDateTime { get; set; }

        /// <summary>
        /// The id of the user who deleted the entity.
        /// </summary>
        TKey? DeletionUserId { get; set; }
    }
}
