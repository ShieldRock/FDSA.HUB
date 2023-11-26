namespace FDSA.Domain.HUB
{
    public class Rate
    {
        public int MealPlanId { get; set; }
        public bool IsCancellable { get; set; }
        public decimal Price { get; set; }
    }
}
