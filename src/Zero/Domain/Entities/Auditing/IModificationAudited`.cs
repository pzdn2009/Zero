using System;

namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// The interface provides modification audit for an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of primary key.</typeparam>
    public interface IModificationAudited<TKey> where TKey : struct
    {
        /// <summary>
        /// The time when the last modification occured.
        /// </summary>
        DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// The id of the user who last modified the entity.
        /// </summary>
        TKey? LastModifierUserId { get; set; }
    }
}
