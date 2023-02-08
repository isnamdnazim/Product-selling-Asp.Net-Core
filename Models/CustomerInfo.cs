using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerID { get; set; }
        public String CustomerName { get; set; }
        public String CustomarPhn { get; set; }
        public String CustomerArea { get; set; }
        public String CustomarAddress { get; set; }
        public String CustomerEmail { get; set; }
    }
}
