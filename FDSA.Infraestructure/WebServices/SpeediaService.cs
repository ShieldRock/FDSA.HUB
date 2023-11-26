using FDSA.Application;
using FDSA.Application.Interfaces;
using FDSA.Application.Interfaces.WebServices;
using FDSA.Domain;

namespace FDSA.Infraestructure.WebServices
{
    public class SpeediaService : ISpeediaService
    {
        private readonly IHotelLegsAPI _hotelApi;

        public SpeediaService(IHotelLegsAPI hotelApi)
        {
            _hotelApi = hotelApi;
        }

        public async Task<HubResponse> SearchDataAsync(HubRequest request)
        {
            var data = await _hotelApi.SendAsync(GetRequest(request));
            return GetResponse(data);
        }

        /// <summary>
        /// Function to map from HubRequest to HotelLegsRequest
        /// I didn't use AutoMapper because AutoMapper uses Reflection and is slower than manual mapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static HotelLegsRequest GetRequest(HubRequest request)
        {
            return new HotelLegsRequest
            {
                Hotel = request.HotelId,
                CheckInDate = request.CheckIn.Date.ToString("yyyy-MM-dd"),
                NumberOfNights = (request.CheckOut - request.CheckIn).Days,
                Guests = request.NumberOfGuests,
                Rooms = request.NumberOfRooms,
                Currency = request.Currency
            };
        }

        /// <summary>
        /// Function to map HotelLegsResponse into HubResponse
        /// I didn't use AutoMapper because AutoMapper uses Reflection and is slower than manual mapping
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static HubResponse GetResponse(HotelLegsResponse response)
        {
            var mappedData = response.Results.OrderBy(order => order.Room).GroupBy(res => res.Room).Select(group => new Room
            {
                RoomId = group.Key,
                Rates = group.OrderBy(order => order.Meal).Select(r => new Rate
                {
                    MealPlanId = r.Meal,
                    IsCancellable = r.CanCancel,
                    Price = r.Price
                }).ToList()
            }).ToList();

            var result = new HubResponse
            {
                Rooms = mappedData
            };

            return result;
        }
    }
}
