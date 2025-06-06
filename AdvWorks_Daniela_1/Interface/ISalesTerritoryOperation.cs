using AdvWorks_Daniela_1.Entities.Sales;

namespace AdvWorks_Daniela_1.Interface
{
    public interface ISalesTerritoryOperation
    {
        Task PutSales(List<SalesTerritoryEntity> sales);
    }
}
