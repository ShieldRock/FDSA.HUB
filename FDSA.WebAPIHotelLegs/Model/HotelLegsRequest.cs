﻿namespace FDSA.WebAPIHotelLegs.Model
{
    public class HotelLegsRequest
    {
        public int Hotel { get; set; }
        public string CheckInDate { get; set; }
        public int NumberOfNights { get; set; }
        public int Guests { get; set; }
        public int Rooms { get; set; }
        public string Currency { get; set; }
    }
}
