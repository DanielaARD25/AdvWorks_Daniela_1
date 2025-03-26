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

        public async Task<SalesTerritory> GetSalesTerritoriesByIdAsync(int id) => await _context.SalesTerritory.FindAsync(id);


        public async Task<IEnumerable<SalesTerritory>> GetSalesTerritoriesAsync() => await _context.SalesTerritory.Take(100).ToListAsync();

        public async Task<SalesTerritory> CreateSalesTerritoriesAsync(SalesTerritory salesTerritory)
        {
            _context.SalesTerritory.Add(salesTerritory);
            await _context.SaveChangesAsync();
            return salesTerritory;
        }

        public async Task<bool> UpdateSalesTerritoriesAsync(SalesTerritory salesTerritory)
        {
            _context.Entry(salesTerritory).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!SalesTerritoryExists(salesTerritory.TerritoryID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteSalesTerritoriesByIdAsync(int id)
        {
            var salesTerritory = await _context.SalesTerritory.FindAsync(id);
            if (salesTerritory == null)
            {
                return false;
            }

            _context.SalesTerritory.Remove(salesTerritory);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool SalesTerritoryExists(int id)
        {
            return _context.SalesTerritory.Any(e => e.TerritoryID == id);
        }
    }
}
