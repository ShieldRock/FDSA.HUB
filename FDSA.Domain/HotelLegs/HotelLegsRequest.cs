namespace FDSA.Domain.HotelLegs
{
    public class HotelLegsRequest
    {
        /// <summary>
        /// The hotel unique identifier
        /// </summary>
        public int Hotel { get; set; }

        /// <summary>
        /// The check-in date
        /// </summary>
        public string CheckInDate { get; set; }

        /// <summary>
        /// The number of nights
        /// </summary>
        public int NumberOfNights { get; set; }

        /// <summary>
        /// The number of guests
        /// </summary>
        public int Guests { get; set; }

        /// <summary>
        /// The number of rooms
        /// </summary>
        public int Rooms { get; set; }

        /// <summary>
        /// The currency abbreviation
        /// </summary>
        public string Currency { get; set; }
    }
}
