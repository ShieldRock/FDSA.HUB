namespace FDSA.Domain.HotelLegs
{
    public class Result
    {
        /// <summary>
        /// The number of the room
        /// </summary>
        public int Room { get; set; }

        /// <summary>
        /// The number of the meal
        /// </summary>
        public int Meal { get; set; }

        /// <summary>
        /// Determines if can cancel reservation
        /// </summary>
        public bool CanCancel { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public decimal Price { get; set; }
    }
}
