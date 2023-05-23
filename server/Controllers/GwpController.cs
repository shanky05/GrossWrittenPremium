using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("server/api/[controller]")]
    [ApiController]
    public class gwpController : ControllerBase
    {

        private readonly IGwpService _gwpService;
        public gwpController(IGwpService gwpService)
        {
            _gwpService = gwpService;
        }

        [HttpPost]
        [Route("avg")]
        public async Task<IActionResult> GetAvgPremium(GwpRequest request)
        {
            if(request == null)
            {
                return BadRequest();
            }
            var result = await _gwpService.GetAvgGrossPremium(request);
            return Ok(result);
        }
    }
}
