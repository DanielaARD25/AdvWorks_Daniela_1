using AdvWorks_Daniela_1.Models;

namespace AdvWorks_Daniela_1.Interface
{
    public interface ISalesTerritoryRepository
    {
        Task<IEnumerable<SalesTerritory>> GetSalesTerritoriesAsync();

        Task<SalesTerritory> GetSalesTerritoriesByIdAsync(int id);

        Task<SalesTerritory> CreateSalesTerritoriesAsync(SalesTerritory salesTerritory);
        
        Task<bool> DeleteSalesTerritoriesByIdAsync(int id);

        Task<bool> UpdateSalesTerritoriesAsync(SalesTerritory salesTerritory);

    }
}
