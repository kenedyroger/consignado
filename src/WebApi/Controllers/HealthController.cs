using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class HealthController : ControllerBase
    {
        [HttpGet("liveness")]
        public IActionResult Liveness()
        {
            return Ok("I'm alive");
        }

        [HttpGet("readiness")]
        public IActionResult Readiness()
        {
            // TODO: Aqui deve se conectar ao banco de dados e executar um select simples para validar a conexão
            return Ok("I'm ready");
        }
    }
}
