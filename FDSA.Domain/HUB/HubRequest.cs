using System.ComponentModel.DataAnnotations;

namespace FDSA.Domain.HUB
{
    public class HubRequest
    {
        /// <summary>
        /// The hotel unique identifier
        /// </summary>
        [Required(ErrorMessage = "The field HotelId is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid integer Number")]
        public int HotelId { get; set; }

        /// <summary>
        /// The check-in date
        /// </summary>
        [Required(ErrorMessage = "The field CheckIn is mandatory")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// The check-out date
        /// </summary>
        [Required(ErrorMessage = "The field CheckOut is mandatory")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// The number of guests
        /// </summary>
        [Required(ErrorMessage = "The field NumberOfGuests is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid integer number")]
        public int NumberOfGuests { get; set; }

        /// <summary>
        /// The number of rooms
        /// </summary>
        [Required(ErrorMessage = "The field NumberOfRooms is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid integer number")]
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// The currency abbreviation
        /// </summary>
        [Required(ErrorMessage = "The field Currency is mandatory")]
        [RegularExpression("^([a-zA-Z]{3})$", ErrorMessage = "Currency is required and must be properly formatted.")]
        public string Currency { get; set; }
    }
}
