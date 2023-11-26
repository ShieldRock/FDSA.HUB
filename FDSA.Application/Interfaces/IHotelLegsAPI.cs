using FDSA.Domain.HotelLegs;

namespace FDSA.Application.Interfaces
{
    public interface IHotelLegsAPI
    {
        Task<HotelLegsResponse> SendAsync(HotelLegsRequest request);
    }
}
