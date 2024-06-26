using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Model;
using WebAPI.Serwice;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlawiaturyController : ControllerBase
    {
        private readonly IService _service;

        public KlawiaturyController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<KlawiaturaResponceDTO> Get()
        {
            var keyboards = _service.getKlawiatury();
            return keyboards;
        }

        [HttpPost]
        public void Post([FromBody] KlawiaturyRequestDTO keyboard)
        {
            _service.PostKlawiatura(keyboard);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteKlawiatury(id);
        }
    }
}
