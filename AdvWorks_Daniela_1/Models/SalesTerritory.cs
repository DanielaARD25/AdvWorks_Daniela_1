using System.ComponentModel.DataAnnotations;
namespace AdvWorks_Daniela_1.Models
{
    public class SalesTerritory
    {
        [Key]
        public required int TerritoryID { get; set; }
        public required string Name { get; set; }
        public required string CountryRegionCode { get; set; }
        public required string Group { get; set; }
        public required decimal SalesYTD { get; set; }
        public required decimal CostYTD { get; set; }
        public required decimal CostLastYear { get; set; }
        public required Guid rowguid { get; set; }
        public required DateTime ModifiedDate { get; set; }


        // Si es un valor nulo, es ejemplo: public string Name {get; set;} = string.Empty;
    }
}
