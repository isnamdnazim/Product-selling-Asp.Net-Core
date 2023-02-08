using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class SalesProduct
    {
        [Key]
        public int SalesProID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal Pvat { get; set; }
        public decimal PDiscount { get; set; }
        public bool Returnable { get; set; }
    }
}
