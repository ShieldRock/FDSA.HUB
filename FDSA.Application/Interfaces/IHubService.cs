using FDSA.Domain;

namespace FDSA.Application.Interfaces
{
    public interface IHubService
    {
        Task<HubResponse> SearchAsync(HubRequest request);
    }
}
