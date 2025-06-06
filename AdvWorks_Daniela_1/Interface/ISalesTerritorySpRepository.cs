using System.Data;

namespace AdvWorks_Daniela_1.Interface
{
    public interface ISalesTerritorySpRepository
    {
        Task PutSalesBySpAsync(DataTable sales);
    }
}
