using FDSA.Domain;

namespace FDSA.Application.Interfaces
{
    public interface IHotelLegsAPI
    {
        Task<HotelLegsResponse> SendAsync(HotelLegsRequest request);
    }
}
