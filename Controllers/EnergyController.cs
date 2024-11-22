using gs2Gb93266Ez92955.Models;
using gs2Gb93266Ez92955.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs2Gb93266Ez92955.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public EnergyController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok(new { status = "Service is running", timestamp = DateTime.UtcNow });
        }

        [HttpPost("consumo")]
        public async Task<IActionResult> RegisterConsumption([FromBody] ConsumptionModel consumo)
        {
            if (consumo == null || consumo.Consumption <= 0)
            {
                return BadRequest(new { error = "Invalid consumption data. Consumption must be greater than 0." });
            }

            consumo.Timestamp = DateTime.UtcNow;

            try
            {
                await _mongoService.AddConsumoAsync(consumo);
                return CreatedAtAction(nameof(RegisterConsumption), new { id = consumo.Id }, consumo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to save data", details = ex.Message });
            }
        }

        [HttpGet("consumo")]
        public async Task<IActionResult> GetConsumption()
        {
            try
            {
                var consumos = await _mongoService.GetConsumosAsync();
                if (consumos == null || consumos.Count == 0)
                {
                    return NotFound(new { error = "No consumption data found." });
                }

                return Ok(consumos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to retrieve data", details = ex.Message });
            }
        }
    }
}
