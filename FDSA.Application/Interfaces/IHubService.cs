using FDSA.Domain.HUB;

namespace FDSA.Application.Interfaces
{
    public interface IHubService
    {
        Task<HubResponse> SearchAsync(HubRequest request);
    }
}
