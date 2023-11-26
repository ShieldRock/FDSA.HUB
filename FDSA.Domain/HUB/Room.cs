namespace FDSA.Domain.HUB
{
    public class Room
    {
        /// <summary>
        /// The room unique identifier
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// The list of rates
        /// </summary>
        public List<Rate> Rates { get; set; } = new List<Rate>();
    }
}
