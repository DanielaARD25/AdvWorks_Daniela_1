using AdvWorks_Daniela_1.Interface;
using AdvWorks_Daniela_1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvWorks_Daniela_1.Data
{
    public class SalesTerritoryRepository : ISalesTerritoryRepository
    {
        private readonly AppDbContext _context;

        public SalesTerritoryRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<SalesTerritory>> GetSalesTerritoriesAsync() => await _context.SalesTerritory.Take(100).ToListAsync();
    }
}
