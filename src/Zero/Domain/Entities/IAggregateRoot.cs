namespace Zero.Domain.Entities
{
    /// <summary>
    /// A shortcut of <see cref="IAggregateRoot{TKey}"/> for the long type.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<long>
    {
    }
}
