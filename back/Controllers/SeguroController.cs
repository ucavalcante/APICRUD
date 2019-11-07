using System;
using System.Collections.Generic;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SeguroController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Seguro> Get()
        {
            return Seguro.GetList();
        }
        [HttpGet]
        [Route("{id}")]
        public Seguro Get(int id)
        {
            return Seguro.Read(id);
        }
        [HttpPost]
        public IActionResult Post(Seguro seguro)
        {
            Seguro.Create(seguro);
            return Accepted();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Seguro.Delete(id);
            return Accepted();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Seguro seguro)
        {
            Seguro.Update(id, seguro);
            return Accepted();
        }

    }
}