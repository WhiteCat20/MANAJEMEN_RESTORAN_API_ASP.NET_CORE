using AutoMapper;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ITDServiceRepository repo;
        private readonly IMapper mapper;

        public ServiceController(ITDServiceRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] AddTDServiceDto request)
        {
            var domain = mapper.Map<TDService>(request);
            domain = await repo.CreateService(domain);
            if(domain == null)
            {
                return BadRequest();
            }
            return Ok(new {message="Berhasil membuat service baru", data= domain});
        }

        
    }
}
