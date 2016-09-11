namespace Zero.Domain.Entities
{
    /// <summary>
    /// Used to distinguish the entity whether is enabled or disabled.
    /// </summary>
    public interface IEnable
    {
        /// <summary>
        /// When the field is true ,the entity is enabled,else the entity is disabled.
        /// </summary>
        bool Enable { get; set; }
    }
}
