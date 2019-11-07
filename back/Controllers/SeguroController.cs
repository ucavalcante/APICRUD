using System;
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
            List<Seguro> mockup = new List<Seguro> {
                new Seguro {
                     Id = 1,
                    Nome = "Veiculo Passeio Nacional",
                    Abrangencia = AbrangenciaEnum.Nacional,
                    DtContratacao = DateTime.Now,
                    VigenciaLimite = DateTime.Now.AddMonths(12)
                },
                new Seguro { 
                    Id = 2,
                    Nome = "Motorista de Aplicativo Estadual",
                    Abrangencia = AbrangenciaEnum.Estadual,
                    DtContratacao = DateTime.Now,
                    VigenciaLimite = DateTime.Now.AddMonths(6)
                }
            };


            return mockup;
        }
        [HttpPost]
        public IActionResult Post(Seguro seguro)
        {

            return null;
        }
    }
}