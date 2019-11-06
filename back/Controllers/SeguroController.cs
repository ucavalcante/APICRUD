using System.Collections.Generic;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Seguro> Get()
        {
            return null;
        }
        [HttpPost]
        public IActionResult Post(Seguro seguro)
        {

            return null;
        }
    }
}