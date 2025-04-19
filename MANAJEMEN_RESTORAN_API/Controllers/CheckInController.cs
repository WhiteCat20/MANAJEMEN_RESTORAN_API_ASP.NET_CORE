using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resto.Domain.DTO;
using Resto.Domain.Entity;
using Resto.Domain.Service;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/check-in")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckinRepository _repo;

        public CheckInController(ICheckinRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var domain = await _repo.GetAll();
            var dto = domain.Select(checkin => checkin.ToDto()).ToList();
            return Ok(dto);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var domain = await _repo.GetById(id);
            var dto = domain?.ToDto();
            return Ok(dto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create([FromBody] AddTHCheckinDirectDto request)
        {
            var domain = new THCheckin()
            {
                MHCabangId = request.MHCabangId,
                MHTableId = request.MHTableId,
                CheckIn = request.CheckIn,
                Duration = request.Duration,
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerTotal = request.CustomerTotal,
            };
            domain = await _repo.CreateDirectly(domain);
            if (domain == null)
            {
                return BadRequest();
            }
            var dto = domain.ToDto();
            return CreatedAtAction(nameof(GetById), dto);
        }

        [HttpPost]
        [Route("add-from-reservation/{THReservationId:int}")]
        public async Task<IActionResult> CreateFromReservation(int THReservationId) 
        {
            var domain = await _repo.CreateFromReservation(THReservationId);
            if (domain == null) {
                return BadRequest();
            }
            var dto = domain.ToDto();
            return Ok(dto);
        }
    }
}
