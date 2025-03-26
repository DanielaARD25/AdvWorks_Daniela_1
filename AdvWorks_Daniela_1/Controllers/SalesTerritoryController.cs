using AdvWorks_Daniela_1.Interface;
using AdvWorks_Daniela_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorks_Daniela_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalesTerritoryController : Controller
    {
        private readonly ISalesTerritoryRepository _repository;

        public SalesTerritoryController(ISalesTerritoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesTerritory>>> GetSalesTerritories()
        {
            var salesTerritories = await _repository.GetSalesTerritoriesAsync();
            return Ok(salesTerritories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesTerritory>> GetSalesTerritoriesById(int id)
        {
            var salesTerritory = await _repository.GetSalesTerritoriesByIdAsync(id);
            if (salesTerritory == null)
            {
                return NotFound();
            }
            return Ok(salesTerritory);
        }

        [HttpPost]
        public async Task<ActionResult<SalesTerritory>> CreateSalesTerritories(SalesTerritory salesTerritory)
        {
            var createdSalesTerritory = await _repository.CreateSalesTerritoriesAsync(salesTerritory);
            return CreatedAtAction(nameof(GetSalesTerritoriesById), new { id = createdSalesTerritory.TerritoryID }, createdSalesTerritory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesTerritories(int id, SalesTerritory salesTerritory)
        {
            if (id != salesTerritory.TerritoryID)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateSalesTerritoriesAsync(salesTerritory);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesTerritoriesById(int id)
        {
            var result = await _repository.DeleteSalesTerritoriesByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
