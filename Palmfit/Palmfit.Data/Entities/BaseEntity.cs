namespace Palmfit.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DateDeleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}