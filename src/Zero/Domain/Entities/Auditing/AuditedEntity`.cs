using System;

namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// Encapsulating the <see cref="IEntity{TKey}"/> and the <see cref="IAudited{TKey}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public abstract class AuditedEntity<TKey> : EntityBase<TKey>, IAudited<TKey> where TKey : struct
    {
        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        public TKey Id
        {
            get; set;
        }

        /// <summary>
        /// The creation time of the entity.
        /// </summary>
        public DateTime CreationTime
        {
            get; set;
        }

        /// <summary>
        /// The creation user id of the entity.
        /// </summary>
        public TKey? CreationUserId
        {
            get; set;
        }
       
        /// <summary>
        /// The last modification time of the entity.
        /// </summary>
        public DateTime? LastModificationTime
        {
            get; set;
        }

        /// <summary>
        /// The last modification user id of the entity.
        /// </summary>
        public TKey? LastModifierUserId
        {
            get; set;
        }
    }
}
