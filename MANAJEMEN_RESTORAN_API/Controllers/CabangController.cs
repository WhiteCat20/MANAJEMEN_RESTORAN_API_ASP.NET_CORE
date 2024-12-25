using AutoMapper;
using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/cabang")]
    [ApiController]

    public class CabangController : ControllerBase
    {
        private readonly RestoDbContext dbContext;
        private readonly ICabangRepository cabangRepository;
        private readonly IMapper mapper;

        public CabangController(RestoDbContext dbContext, ICabangRepository cabangRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.cabangRepository = cabangRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var customersDomain = dbContext.mh_customer.ToList();
            var domain = await cabangRepository.GetAllAsync();
            var dto = mapper.Map<List<MHCabangDto>>(domain);
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var customerDomain = await dbContext.mh_customer.FirstOrDefaultAsync(x => x.id == id);
            var domain = await cabangRepository.GetByIdAsync(id);
            if (domain == null)
            {
                return NotFound("ga ada");
            }

            var dto = mapper.Map<MHCabangDto>(domain);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMHCabangRequestDto requestDto)
        {
            // map from dto to domain model
            var domain = mapper.Map<MHCabang>(requestDto);
            domain = await cabangRepository.CreateAsync(domain);

            // map from domain back to dto
            var dto = mapper.Map<MHCabangDto>(domain);

            return CreatedAtAction(nameof(GetById), new { id = dto.id }, dto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateMHCustomerRequestDto updateRequestDto
        )
        {
            // map dto to domain model
            var domain = mapper.Map<MHCabang>(updateRequestDto);

            domain = await cabangRepository.UpdateAsync(id, domain);

            if (domain == null)
            {
                return NotFound();
            }

            // map domain model to dto back
            var dto = mapper.Map<MHCabangDto>(domain);

            return Ok(dto);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var domain = await cabangRepository.DeleteAsync(id);
            if (domain == null) { return NotFound(); }

            // map domain to dto
            var dto = mapper.Map<MHCabangDto>(domain);
            return Ok(dto);
        }
    }
}

