using FDSA.Application.Interfaces;
using FDSA.Domain.HUB;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FDSA.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HubController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private readonly ILogger<HubController> _logger;
        private readonly IHubService _hubService;
        #endregion

        #region CONSTRUCTORS
        public HubController(
            ILogger<HubController> logger,
            IHubService hubService
        )
        {
            _logger = logger;
            _hubService = hubService;
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Function to search
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = "Search")]
        public async Task<IActionResult> SearchAsync(HubRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return BadRequest(errors);
                }

                _logger.LogInformation($"Request incoming: {JsonSerializer.Serialize(request)}");
                var result = await _hubService.SearchAsync(request);
                _logger.LogInformation($"Response outcoming: {JsonSerializer.Serialize(result)}");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    }
}
