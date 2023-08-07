namespace Palmfit.Data.Entities
{
    public class Wallet : BaseEntity
    {
        public readonly object Transaction;

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}