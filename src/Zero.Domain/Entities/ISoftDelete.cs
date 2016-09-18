namespace Zero.Domain.Entities
{
    /// <summary>
    /// The interface provides a mechanism that entities are not deleted
    /// really ,they just set the IsDelete field to true/1 when Delete method called.
    /// Also when query the soft-delete entities from db, they will not be included.
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Mark an entity as 'Deleted'.
        /// </summary>
        bool IsDelete { get; set; }
    }
}
