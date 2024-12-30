using AutoMapper;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/check-in")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckinRepository repo;
        private readonly IMapper mapper;

        public CheckInController(ICheckinRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repo.GetAll();
            var dto = mapper.Map<List<THCheckinDto>>(domain);
            return Ok(dto);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var domain = await repo.GetById(id);
            var dto = mapper.Map<THCheckinDto>(domain);
            return Ok(dto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] AddTHCheckinDirectDto request)
        {
            var domain = mapper.Map<THCheckin>(request);
            domain = await repo.CreateDirectly(domain);
            if (domain == null)
            {
                return BadRequest();
            }
            var dto = mapper.Map<THCheckinDto>(domain);
            return CreatedAtAction(nameof(GetById), dto);
        }

        [HttpPost]
        [Route("add-from-reservation/{THReservationId:int}")]
        public async Task<IActionResult> CreateFromReservation(int THReservationId) 
        {
            var domain = await repo.CreateFromReservation(THReservationId);
            if (domain == null) {
                return BadRequest();
            }
            var dto = mapper.Map<THCheckinDto>(domain);
            return Ok(dto);
        }
    }
}
