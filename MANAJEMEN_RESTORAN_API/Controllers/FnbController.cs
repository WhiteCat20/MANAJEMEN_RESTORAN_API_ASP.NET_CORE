using AutoMapper;
using MANAJEMEN_RESTORAN_API.Mappings;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/fnb")]
    [ApiController]
    public class FnbController : ControllerBase
    {
        private readonly IFnbRepository repo;
        private readonly IMapper mapper;

        public FnbController(IFnbRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repo.GetAllFnb();
            var dto = MHFnbMapper.MapToDtoList(domain);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMHFnbRequestDto request)
        {
            // dto to domain using automapper
            var domain = mapper.Map<MHFnb>(request);
            domain = await repo.CreateFnb(domain);
            // domain to dto using self-made mapper
            var dto = MHFnbMapper.MapToDto(domain);
            return CreatedAtAction(nameof(GetAll), dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await repo.SoftDelete(id);
            return NoContent();
        }
    }
}
