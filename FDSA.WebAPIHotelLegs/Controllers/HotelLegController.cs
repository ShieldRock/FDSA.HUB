using FDSA.WebAPIHotelLegs.Model;
using Microsoft.AspNetCore.Mvc;

namespace FDSA.WebAPIHotelLegs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HotelLegController : ControllerBase
    {
        private readonly ILogger<HotelLegController> _logger;

        public HotelLegController(ILogger<HotelLegController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Search")]
        public async Task<IActionResult> SearchAsync(HotelLegsRequest request)
        {
            return Ok(await Task.Run(GetResponse));
        }

        private static HotelLegsResponse GetResponse()
        {
            return new HotelLegsResponse
            {
                Results = new List<Result>()
                {
                    new Result
                    {
                        Room = 1,
                        Meal = 2,
                        CanCancel = false,
                        Price = 123.48m
                    },
                    new Result
                    {
                        Room = 1,
                        Meal = 1,
                        CanCancel = true,
                        Price = 150.00m
                    },
                    new Result
                    {
                        Room = 2,
                        Meal = 1,
                        CanCancel = false,
                        Price = 148.25m
                    },
                    new Result
                    {
                        Room = 2,
                        Meal = 2,
                        CanCancel = false,
                        Price = 165.38m
                    }
                }
            };
        }
    }
}
