using Microsoft.AspNetCore.Mvc;

namespace CaraOuCoroa.Controllers
{
    [ApiController]
    [Route("api")]
    public class JogarController : ControllerBase
    {
        [HttpGet]
        public CaraOuCoroaResultado Get()
        {
            return new CaraOuCoroaResultado();
        }
    }
}
