using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
