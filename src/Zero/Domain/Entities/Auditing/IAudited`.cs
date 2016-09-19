namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// The combination of <see cref="ICreationAudited{TKey}"/> 
    /// and <see cref="IModificationAudited{TKey}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public interface IAudited<TKey> : ICreationAudited<TKey>,
        IModificationAudited<TKey> where TKey : struct
    {
    }
}
