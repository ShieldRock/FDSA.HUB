﻿namespace FDSA.Domain
{
    public class Room
    {
        public int RoomId { get; set; }
        public List<Rate> Rates { get; set; } = new List<Rate>();
    }
}
