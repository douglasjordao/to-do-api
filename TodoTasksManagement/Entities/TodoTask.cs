using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TodoTasksManagement.Entities;

namespace Entities
{
    [Serializable]
    public class TodoTask : BaseEntity
    {
        public TodoTask()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [MaxLength(36)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [MaxLength(100)]
        [AllowNull]
        public string? Description { get; set; }

        public void Validate()
        {
            var validationContext = new ValidationContext(this);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
            {
                throw new Exceptions.ValidationException(validationResults);
            }
        }
    }
}