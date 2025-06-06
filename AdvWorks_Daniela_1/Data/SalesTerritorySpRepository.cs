using AdvWorks_Daniela_1.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AdvWorks_Daniela_1.Data
{
    public class SalesTerritorySpRepository : ISalesTerritorySpRepository
    {
        private readonly AppDbContext _context;

        public SalesTerritorySpRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task PutSalesBySpAsync(DataTable sales)
        {
            var cnx = _context.Database.GetDbConnection();
            await using (cnx)
            {
                if (cnx.State != ConnectionState.Open)
                    await cnx.OpenAsync();

                using var command = cnx.CreateCommand();
                command.CommandText = "usp_oe_PutSalesTerritoryTbl_v1";
                command.CommandType = CommandType.StoredProcedure;
                var salesParam = new SqlParameter("@SalesTerritoryTable", SqlDbType.Structured)
                {
                    Value = sales,
                    TypeName = "dbo.SalesTerritoryTblType" // Usa el nombre exacto como está en SQL Server
                };
                command.Parameters.Add(salesParam);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
