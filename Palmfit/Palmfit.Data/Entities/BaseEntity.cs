using System.ComponentModel.DataAnnotations;

namespace Palmfit.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}