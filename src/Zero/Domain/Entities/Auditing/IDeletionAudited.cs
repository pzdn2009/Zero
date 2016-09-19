namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// A shotcut of <see cref="IDeletionAudited{TKey}"/> for the long type.
    /// </summary>
    public interface IDeletionAudited : IDeletionAudited<long>
    {
    }
}
