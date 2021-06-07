using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCSharp_RetailerOffers
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer() { }

        public Customer(string name)
        {
            Name = name;
        }
    }

    class Transactions : Customer
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }

    class Rewards:Customer
    {
        public int TotalPoints { get; set; }
        public string Month { get; set; }     
        public string Year { get; set; }     
    }
}
