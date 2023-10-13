using System.Text.Json.Serialization;

namespace TodoTasksManagement.Entities
{
    public class BaseEntity
    {
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}