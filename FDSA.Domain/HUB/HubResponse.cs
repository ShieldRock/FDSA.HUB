namespace FDSA.Domain.HUB
{
    public class HubResponse
    {
        /// <summary>
        /// The list of rooms
        /// </summary>
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
