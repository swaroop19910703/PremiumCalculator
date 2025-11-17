using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Models;
using PremiumCalculator.Services;

namespace PremiumCalculator.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremiumApiController : ControllerBase
    {
        private readonly IPremiumService _service;

        public PremiumApiController(IPremiumService service)
        {
            _service = service;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] MemberInput input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = _service.CalculatePremium(input);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
