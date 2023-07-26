using Palmfit.Data.EntityEnums;

namespace Palmfit.Data.Entities
{
    public class Health
    {
        public int AppUserId { get; set; }
        public double Height { get; set; }
        public HeightUnit HeightUnit { get; set; }
        public double Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public GenoType GenoType { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<WalletHistory> Histories { get; set; }
    }
}