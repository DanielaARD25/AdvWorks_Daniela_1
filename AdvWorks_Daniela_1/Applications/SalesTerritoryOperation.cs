using AdvWorks_Daniela_1.Entities.Sales;
using AdvWorks_Daniela_1.Interface;
using System.Data;

namespace AdvWorks_Daniela_1.Applications
{
    public class SalesTerritoryOperation : ISalesTerritoryOperation
    {
        private readonly ISalesTerritorySpRepository _repository;
        public SalesTerritoryOperation(ISalesTerritorySpRepository repository)
        {
            _repository = repository;
        }


        public async Task PutSales(List<SalesTerritoryEntity> sales)
        {
            var dtSales = await TransformDTSales(sales);
            await _repository.PutSalesBySpAsync(dtSales);
        }

        private Task<DataTable> TransformDTSales(List<SalesTerritoryEntity> sales)
        {
            var table = new DataTable();

            table.Columns.Add("TerritoryID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("CountryRegionCode", typeof(string));
            table.Columns.Add("Group", typeof(string));
            table.Columns.Add("SalesYTD", typeof(decimal));
            table.Columns.Add("CostYTD", typeof(decimal));
            table.Columns.Add("CostLastYear", typeof(decimal));
            table.Columns.Add("rowguid", typeof(Guid));
            table.Columns.Add("ModifiedDate", typeof(DateTime));

            foreach (var s in sales)
            {
                table.Rows.Add(
                    s.TerritoryID,
                    s.Name,
                    s.CountryRegionCode,
                    s.Group,
                    s.SalesYTD,
                    s.CostYTD,
                    s.CostLastYear,
                    s.rowguid,
                    s.ModifiedDate
                );
            }

            return Task.FromResult(table);
        }
    }
}
