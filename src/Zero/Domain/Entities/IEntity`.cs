namespace Zero.Domain.Entities
{
    /// <summary>
    /// Define an interface representes the DDD Entity, has a property named Id, which is generic type.
    /// </summary>
    /// <typeparam name="TPrimaryKey">The type of primary key.</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Identity the entity object.
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 是否新建的对象
        /// </summary>
        bool IsNewCreate();
    }
}
