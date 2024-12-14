using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;
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

        public CustomerController(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customersDomain = dbContext.mh_customer.ToList();
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
            var customerDomain = await dbContext.mh_customer.FirstOrDefaultAsync(x => x.id == id);
            if (customerDomain == null)
            {
                return NotFound("ga ada");
            }

            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name= customerDomain.customer_name,
                customer_phone= customerDomain.customer_phone
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

            await dbContext.mh_customer.AddAsync(customerDomain);
            await dbContext.SaveChangesAsync();

            var customerDto = new MHCustomerDto
            {
                id = customerDomain.id,
                customer_name = customerDomain.customer_name,
                customer_phone = customerDomain.customer_phone
            };

            return CreatedAtAction(nameof(GetById), new { id = customerDto.id }, customerDto);
        }
    }
}
