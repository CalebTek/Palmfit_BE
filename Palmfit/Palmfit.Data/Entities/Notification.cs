namespace Palmfit.Data.Entities
{
    public class Notification : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}