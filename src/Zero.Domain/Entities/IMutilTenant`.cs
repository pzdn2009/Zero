namespace Zero.Domain.Entities
{
    /// <summary>
    /// Used to isolate the user's datas with a tenant id.
    /// </summary>
    /// <typeparam name="TKey">The type of the tenant id.</typeparam>
    public interface IMutilTenant<TKey> where TKey : struct
    {
        /// <summary>
        /// The tenant id of the entity.
        /// </summary>
        TKey? TenantId { get; set; }
    }
}
