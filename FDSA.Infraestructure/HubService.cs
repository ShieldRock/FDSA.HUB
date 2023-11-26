using FDSA.Application.Interfaces;
using FDSA.Application.Interfaces.WebServices;
using FDSA.Application.Interfaces.WebServices.Shared;
using FDSA.Domain.HUB;
using FDSA.Infraestructure.WebServices.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FDSA.Infraestructure
{
    public class HubService : IHubService
    {
        private readonly IHotelLegsService _hotelLegsService;
        private readonly IServiceProvider _serviceProvider;

        public HubService(IHotelLegsService hotelLegsService, IServiceProvider serviceProvider)
        {
            _hotelLegsService = hotelLegsService;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Function to send data from HUB to all providers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HubResponse> SearchAsync(HubRequest request)
        {
            HubResponse result = new HubResponse();
            var implementations = typeof(ProviderService).Assembly.GetTypes()
                .Where(w => w.IsAssignableTo(typeof(IProviderService)) && !w.IsAbstract && !w.IsInterface && !w.Name.Equals(nameof(ProviderService)))
                .Select(item => ActivatorUtilities.CreateInstance(_serviceProvider, item))
                .Cast<IProviderService>();

            foreach (var implementation in implementations)
            {
                var serviceResponse = await implementation.SearchDataAsync(request);

                if (serviceResponse != null)
                {
                    result.Rooms.AddRange(serviceResponse.Rooms);
                }
            }

            return result;
        }
    }
}
