namespace TestProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductTittle { get; set; }
        public string ProductCode { get; set; }
        public decimal SalesPrice { get; set; }
        public int InitialProductStockQty { get; set; }
        public int RemainingQty { get; set; }
        public int QRId { get; set; }
        public string PPicture { get; set; }
    }
}
