using AutoMapper;
using MANAJEMEN_RESTORAN_API.Models.DTO;
using MANAJEMEN_RESTORAN_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository tableRepository;
        private readonly IMapper mapper;

        public TableController(ITableRepository tableRepository, IMapper mapper)
        {
            this.tableRepository = tableRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await tableRepository.GetAllAsync();
            var dto = mapper.Map<List<MHTableDto>>(domain);
            return Ok(dto);
        }

    }
}
