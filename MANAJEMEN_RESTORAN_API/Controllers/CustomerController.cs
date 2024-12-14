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

        public CustomerController(RestoDbContext dbContext, ICustomerRepository customerRepository)
        {
            this.dbContext = dbContext;
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var customersDomain = dbContext.mh_customer.ToList();
            var customersDomain = await customerRepository.GetAllAsync();
            var customersDto = new List<MHCustomerDto>();
            foreach (var customer in customersDomain)
            {
                customersDto.Add(new MHCustomerDto()
                {
                    id = customer.id,
                    customer_name = customer.customer_name,
                    customer_phone = customer.customer_phone,
                });
            }
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

            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name = customerDomain.customer_name,
                customer_phone = customerDomain.customer_phone
            };

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddMHCustomerRequestDto requestDto)
        {
            // map from dto to domain model
            var customerDomain = new MHCustomer
            {
                customer_name = requestDto.customer_name,
                customer_phone = requestDto.customer_phone
            };

            customerDomain = await customerRepository.CreateAsync(customerDomain);

            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name = customerDomain.customer_name,
                customer_phone = customerDomain.customer_phone
            };

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
            var customerDomain = new MHCustomer
            {
                customer_name = updateRequestDto.customer_name,
                customer_phone = updateRequestDto.customer_phone
            };

            customerDomain = await customerRepository.UpdateAsync(id, customerDomain);

            if (customerDomain == null)
            {
                return NotFound();
            }

            // map domain model to dto back
            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name = customerDomain.customer_name,
                customer_phone = customerDomain.customer_phone
            };

            return Ok(customerDto);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customerDomain = await customerRepository.DeleteAsync(id);
            if(customerDomain == null) { return NotFound(); }

            // map domain to dto
            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name = customerDomain.customer_name,
                customer_phone = customerDomain.customer_phone
            };
            return Ok(customerDto);
        }
    }
}
