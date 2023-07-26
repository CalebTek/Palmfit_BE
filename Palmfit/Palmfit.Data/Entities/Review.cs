namespace Palmfit.Data.Entities
{
    public class Review : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string Verdict { get; set; } // There is a comment property, why verdict?
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}