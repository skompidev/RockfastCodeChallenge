namespace Rockfast.ApiDatabase.DomainModels
{
    public class Todo : Entity<int>
    {
        public string Name { get; set; } = default!;        
        public DateTime? DateCompleted { get; set; }

        public Guid UserId { get; set; } = default!;
    }
}
