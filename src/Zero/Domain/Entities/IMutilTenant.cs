namespace Zero.Domain.Entities
{
    /// <summary>
    /// A shortcut of <see cref="IMutilTenant{TKey}"/> for the long type.
    /// </summary>
    public interface IMutilTenant : IMutilTenant<long>
    {
    }
}
