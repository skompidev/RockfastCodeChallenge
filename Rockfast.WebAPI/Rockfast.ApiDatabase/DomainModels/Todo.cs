using System.ComponentModel.DataAnnotations;

namespace Rockfast.ApiDatabase.DomainModels
{
    public class Todo : Entity<int>
    {
        [Required]
        public string Name { get; set; } = default!;        
        public DateTime? DateCompleted { get; set; }
    }
}
