namespace Zero.Domain.Entities
{
    /// <summary>
    /// A shortcut of <see cref="IEntity{TKey}"/> for the long type.
    /// </summary>
    public interface IEntity : IEntity<long>
    {
    }
}
