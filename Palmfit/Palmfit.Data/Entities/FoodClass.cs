namespace Palmfit.Data.Entities
{
    public class FoodClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}