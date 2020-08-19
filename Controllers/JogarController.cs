using Microsoft.AspNetCore.Mvc;

namespace CaraOuCoroa.Controllers
{
    [ApiController]
    [Route("")]
    public class JogarController : ControllerBase
    {
        [HttpGet]
        public CaraOuCoroaResultado Get()
        {
            return new CaraOuCoroaResultado();
        }
    }
}
