using System.ComponentModel.DataAnnotations;

namespace AssignmentAgiblocks.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CounterPartID { get; set; }
        public string CompanyName { get; set; }
        public string IsBuyer { get; set; }
        public string IsSeller { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
