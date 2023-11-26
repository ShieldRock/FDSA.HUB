namespace FDSA.Domain.HUB
{
    public class Rate
    {
        /// <summary>
        /// The meal plan unique identifier
        /// </summary>
        public int MealPlanId { get; set; }

        /// <summary>
        /// Determines if the rate is cancellable
        /// </summary>
        public bool IsCancellable { get; set; }

        /// <summary>
        /// The price of the rate
        /// </summary>
        public decimal Price { get; set; }
    }
}
