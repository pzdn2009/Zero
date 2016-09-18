namespace Zero.Domain.Entities.Auditing
{
    /// <summary>
    /// A shotcut of <see cref="IAudited{TKey}"/> for the long type.
    /// </summary>
    public interface IAudited : IAudited<long>
    {
    }
}
