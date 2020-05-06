using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Policy
    {
        public PolicyType Type { get; set; }

        // for life insurence
        // this are the attribute for the life insurence
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }

        // for land
        
        public string Address { get; set; }
        public decimal size { get; set; }
        public decimal Valuation { get; set; }
        public decimal BondAmount { get; set; }

        // Auto 

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public decimal Deductible { get; set; }
    }
}
