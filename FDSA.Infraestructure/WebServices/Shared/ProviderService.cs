using FDSA.Application.Interfaces.WebServices.Shared;
using FDSA.Domain.HUB;

namespace FDSA.Infraestructure.WebServices.Shared
{
    public class ProviderService : IProviderService
    {
        #region PUBLIC FUNCTIONS
        public async Task<HubResponse> SearchDataAsync(HubRequest request)
        {
            return null;
        }
        #endregion
    }
}
