using System.Collections.Generic;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SeguroController : ControllerBase
    {
        private readonly IDataRepository<Seguro> _dataRepository;
        // private readonly SeguroManager seguro;
        public SeguroController(IDataRepository<Seguro> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        public IEnumerable<Seguro> Get()
        {
            
            return _dataRepository.GetList();
        }
        [HttpGet]
        [Route("{id}")]
        public Seguro Get(int id)
        {
            return _dataRepository.Read(id);
        }
        [HttpPost]
        public IActionResult Post(Seguro seguro)
        {
            _dataRepository.Create(seguro);
            return Accepted();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _dataRepository.Delete(id);
            return Accepted();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Seguro seguro)
        {
            _dataRepository.Update(id, seguro);
            return Accepted();
        }

    }
}