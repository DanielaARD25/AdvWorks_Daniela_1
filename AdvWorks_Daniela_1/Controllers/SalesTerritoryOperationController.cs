using AdvWorks_Daniela_1.Interface;
using Microsoft.AspNetCore.Mvc;
using AdvWorks_Daniela_1.Entities.Sales;

namespace AdvWorks_Daniela_1.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SalesBulkController : Controller
        {
            private readonly ISalesTerritoryOperation _salesOperation;

            public SalesBulkController(ISalesTerritoryOperation salesOperation)
            {
                _salesOperation = salesOperation;
            }

            [HttpPut]
            public async Task<IActionResult> PutSales([FromBody] List<SalesTerritoryEntity> sales)
            {
                if (sales == null || sales.Count == 0)
                {
                    return BadRequest("Sales Territory list is empty.");
                }

                await _salesOperation.PutSales(sales);
                return NoContent();
            }
        }
    
}
