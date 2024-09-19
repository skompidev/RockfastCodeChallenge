namespace Rockfast.ApiDatabase.DomainModels
{
    public class User : Entity<Guid>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<Todo> Todos { get; set; } = default!;
    }
}
