namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// A shotcut of <see cref="ICreationAudited{TKey}"/> for the long type.
    /// </summary>
    public interface ICreationAudited : ICreationAudited<long>
    {
    }
}
