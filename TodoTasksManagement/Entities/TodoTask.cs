using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TodoTask
    {
        [Key]
        [MaxLength(32)]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool Done { get; set; }
    }
}