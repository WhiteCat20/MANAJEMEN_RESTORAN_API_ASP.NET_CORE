using Microsoft.AspNetCore.Mvc;
using Resto.Domain.DTO;
using Resto.Domain.Entity;
using Resto.Domain.Service;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _repo;

        public ReservationController(IReservationRepository repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var domain = await _repo.GetAll();
            var dto = domain.Select(reservation => reservation.ToDto()).ToList();
            return Ok(dto); 
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            var domain = await _repo.GetById(id);
            var dto = domain.ToDto();
            return Ok(dto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTHReservationRequestDto request)
        {
            var domain = new THReservation()
            {
                ReservationTime = request.ReservationTime,
                ReservationDuration = request.ReservationDuration,
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerTotal = request.CustomerTotal,
                DownPayment = request.DownPayment,
            };
            domain = await _repo.Create(domain);
            if (domain == null)
            {
                return BadRequest();
            }
            var dto = domain.ToDto();
            return CreatedAtAction(nameof(GetAll),dto);
        }

    }
}
