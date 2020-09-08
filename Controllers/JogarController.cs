using Microsoft.AspNetCore.Mvc;
using System;

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
