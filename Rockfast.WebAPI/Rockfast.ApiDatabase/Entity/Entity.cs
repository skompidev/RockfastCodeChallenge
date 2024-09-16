
namespace Rockfast.ApiDatabase.Entity
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; } = default!;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
