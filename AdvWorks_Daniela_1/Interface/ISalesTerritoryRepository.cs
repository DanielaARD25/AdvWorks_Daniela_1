using AdvWorks_Daniela_1.Models;

namespace AdvWorks_Daniela_1.Interface
{
    public interface ISalesTerritoryRepository
    {
        Task<IEnumerable<SalesTerritory>> GetSalesTerritoriesAsync();
    }
}
