using AutoMapper;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository repo;
        private readonly IMapper mapper;

        public ReservationController(IReservationRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var domain = await repo.GetAll();
            var dto = mapper.Map<List<THReservationDto>>(domain);
            return Ok(dto); 
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            var domain = await repo.GetById(id);
            var dto = mapper.Map<THReservationDto>(domain);
            return Ok(dto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTHReservationRequestDto request) 
        { 
            var domain = mapper.Map<THReservation>(request);
            domain = await repo.Create(domain);
            if (domain == null)
            {
                return BadRequest();
            }
            var dto = mapper.Map<THReservationDto>(domain);
            return CreatedAtAction(nameof(GetAll),dto);
        }

    }
}
