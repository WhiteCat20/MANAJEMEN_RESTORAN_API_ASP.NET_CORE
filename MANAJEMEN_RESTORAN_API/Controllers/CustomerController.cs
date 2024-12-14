using MANAJEMEN_RESTORAN_API.Data;
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
            foreach (var customer in customersDomain) {
                customersDto.Add(new MHCustomerDto()
                {
                    id = customer.id,
                    customer_name = customer.customer_name,
                    customer_phone = customer.customer_phone,
                });
            }
            return Ok(customersDto);
        }

        [HttpGet]
        [Route("cabang")]
        public IActionResult GetAllCabang() {
            var cabangsDomain = dbContext.mh_cabang.ToList();
            var cabangsDto = new List<MHCabangDto>();
            foreach (var cabang in cabangsDomain)
            {
                cabangsDto.Add(new MHCabangDto()
                {
                    id = cabang.id,
                    name = cabang.name,
                    jumlah_lantai = cabang.jumlah_lantai,
                    kota = cabang.kota
                });
            }
            return Ok(cabangsDto);
        }
    }
}
