using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CounterPartID { get; set; }
        public string CompanyName { get; set; }
        public string IsBuyer { get; set; }
        public string IsSeller { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public Customer(string counterPartID, string companyName, string isBuyer, string isSeller, string phone, string fax)
        {
            CounterPartID = counterPartID;
            CompanyName = companyName;
            IsBuyer = isBuyer;
            IsSeller = isSeller;
            Phone = phone;
            Fax = fax;
        }
        public Customer()
        {
        }
    }
}
