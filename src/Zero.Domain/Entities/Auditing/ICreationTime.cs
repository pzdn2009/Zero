using System;

namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// The interface provides creation time audit for an entity.
    /// </summary>
    public interface ICreationTime
    {
        /// <summary>
        /// The entity's creation datetime.
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
