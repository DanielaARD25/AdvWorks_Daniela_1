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
            // Implement the method logic here  
        }
    }
}
