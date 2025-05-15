using MANAJEMEN_RESTORAN_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Resto.Domain.DTO;
using Resto.Domain.Entity;
using Resto.Domain.Service;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customersDomain = await _customerRepository.GetAllAsync();
            var customersDto = customersDomain.Select(customer => customer.ToDto()).ToList();
            return Ok(customersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerDomain = await _customerRepository.GetByIdAsync(id);
            if (customerDomain == null)
            {
                return NotFound("ga ada");
            }

            var customerDto = customerDomain.ToDto();

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddMHCustomerRequestDto requestDto)
        {
            // map from dto to domain model
            var customerDomain = new MHCustomer()
            {
                CustomerName = requestDto.CustomerName,
                CustomerPhone = requestDto.CustomerPhone
            };
            customerDomain = await _customerRepository.CreateAsync(customerDomain);

            // map from domain back to dto
            var customerDto = customerDomain.ToDto();
            return CreatedAtAction(nameof(GetById), new { id = customerDto.Id }, customerDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(
            [FromRoute] int id,
            [FromBody] UpdateMHCustomerRequestDto updateRequestDto
        )
        {
            // map dto to domain model
            var customerDomain = new MHCustomer()
            {
                CustomerName = updateRequestDto.CustomerName,
                CustomerPhone = updateRequestDto.CustomerPhone
            };

            customerDomain = await _customerRepository.UpdateAsync(id, customerDomain);

            if (customerDomain == null)
            {
                return NotFound();
            }

            // map domain model to dto back
            var customerDto = customerDomain.ToDto();

            return Ok(customerDto);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customerDomain = await _customerRepository.DeleteAsync(id);
            if(customerDomain == null) { return NotFound(); }

            // map domain to dto
            var customerDto = customerDomain.ToDto();
            return Ok(customerDto);
        }
    }
}
