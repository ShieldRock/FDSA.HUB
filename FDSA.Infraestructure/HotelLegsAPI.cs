using FDSA.Application.Interfaces;
using FDSA.Domain.HotelLegs;
using Newtonsoft.Json;
using System.Text;

namespace FDSA.Infraestructure
{
    public class HotelLegsAPI : IHotelLegsAPI
    {
        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Function to send the request to Wthe WebService HotelLegs
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HotelLegsResponse> SendAsync(HotelLegsRequest request)
        {
            try
            {
                HotelLegsResponse result = new HotelLegsResponse();

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7289/");
                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("api/HotelLeg/Search", content);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var message = await response.Content.ReadAsStringAsync();

                        if (message != null)
                        {
                            result = JsonConvert.DeserializeObject<HotelLegsResponse>(message);
                        }
                    }
                }

                return result;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
