using AutoMapper;
using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly RestoDbContext dbContext;
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerController(RestoDbContext dbContext, ICustomerRepository customerRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var customersDomain = dbContext.mh_customer.ToList();
            var customersDomain = await customerRepository.GetAllAsync();
            var customersDto = mapper.Map<List<MHCustomerDto>>(customersDomain);
            return Ok(customersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var customerDomain = await dbContext.mh_customer.FirstOrDefaultAsync(x => x.id == id);
            var customerDomain = await customerRepository.GetByIdAsync(id);
            if (customerDomain == null)
            {
                return NotFound("ga ada");
            }

            var customerDto = mapper.Map<MHCustomerDto>(customerDomain);

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddMHCustomerRequestDto requestDto)
        {
            // map from dto to domain model
            var customerDomain = mapper.Map<MHCustomer>(requestDto);
            customerDomain = await customerRepository.CreateAsync(customerDomain);

            // map from domain back to dto
            var customerDto = mapper.Map<MHCustomerDto>(customerDomain);

            return CreatedAtAction(nameof(GetById), new { id = customerDto.id }, customerDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(
            [FromRoute] int id,
            [FromBody] UpdateMHCustomerRequestDto updateRequestDto
        )
        {
            // map dto to domain model
            var customerDomain = mapper.Map<MHCustomer>(updateRequestDto);

            customerDomain = await customerRepository.UpdateAsync(id, customerDomain);

            if (customerDomain == null)
            {
                return NotFound();
            }

            // map domain model to dto back
            var customerDto = mapper.Map<MHCustomerDto>(customerDomain);

            return Ok(customerDto);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customerDomain = await customerRepository.DeleteAsync(id);
            if(customerDomain == null) { return NotFound(); }

            // map domain to dto
            var customerDto = mapper.Map<MHCustomerDto>(customerDomain);
            return Ok(customerDto);
        }
    }
}
