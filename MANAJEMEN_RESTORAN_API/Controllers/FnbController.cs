using Microsoft.AspNetCore.Mvc;
using Resto.Domain.DTO;
using Resto.Domain.Entity;
using Resto.Domain.Service;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/fnb")]
    [ApiController]
    public class FnbController : ControllerBase
    {
        private readonly IFnbRepository _repo;

        public FnbController(IFnbRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await _repo.GetAllFnb();
            var dto = domain.Select(fnb => fnb.ToDto()).ToList();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMHFnbRequestDto request)
        {
            // dto to domain using automapper
            var domain = new MHFnb()
            {
                Name = request.Name,
                Type = request.Type,
                Price = request.Price,
                ColdHotAvailable = request.ColdHotAvailable
            };
            domain = await _repo.CreateFnb(domain);
            // domain to dto using self-made mapper
            var dto = domain?.ToDto();
            return CreatedAtAction(nameof(GetAll), dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _repo.SoftDelete(id);
            return NoContent();
        }
    }
}
