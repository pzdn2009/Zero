namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// A shotcut of <see cref="IModificationAudited{TKey}"/> for the long type.
    /// </summary>
    public interface IModificationAudited : IModificationAudited<long>
    {
    }
}
