using Microsoft.AspNetCore.Mvc;
using Resto.Domain.Service;

namespace MANAJEMEN_RESTORAN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await _tableRepository.GetAllAsync();
            var dto = domain.Select(table => table.ToDto()).ToList();
            return Ok(dto);
        }
    }
}
