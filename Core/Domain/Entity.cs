namespace Core.Domain
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public class Entity<TKey>
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        public TKey Id { get; set; }
    }
}
