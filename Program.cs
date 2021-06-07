using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleCSharp_RetailerOffers
{
    class ProgLiam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Started.  \r\n");
            List<Transactions> transactions = IntializePurchase();
            Console.WriteLine(" Customer Data intialized in the list. \r\n");
            Console.WriteLine("Customer Data Available in the Data Set. Avaialable transactions are : \r\n");
            string availableNames = null;           
            foreach (var grpByNametransaction in transactions.GroupBy(x => x.Name))
            {                           
                    availableNames = availableNames + grpByNametransaction.FirstOrDefault().Name +" , ";
            }
            Console.Write("Available Names: " + availableNames+ "\r\n");
            Console.Write("Available Months: " + " Jun,Jul,Aug \r\n");
            Console.Write("Available Years: " + " 2020" + "\r\n");
            string Name;
            Console.Write("Enter Name: ");
            Name = Console.ReadLine().ToLower();
            string Month;
            Console.Write("Enter Month: ");
            Month = Console.ReadLine().ToLower();
            string Year;
            Console.Write("Enter Year: ");
            Year = Console.ReadLine();
            List<Rewards> rewardPoints = new List<Rewards>();
            foreach (var grpByNametransaction in transactions.GroupBy(x => x.Name))
            {
                int i = 1;
                foreach (var grpByMonthTransaction in grpByNametransaction.GroupBy(x=>x.Date.Month))
                {
                    Rewards rewards = new Rewards();
                    rewards.Id = 1;
                    rewards.Name = grpByMonthTransaction.FirstOrDefault().Name;
                    rewards.Month= grpByMonthTransaction.FirstOrDefault().Date.ToString("MMM", CultureInfo.InvariantCulture);
                    rewards.Year = grpByMonthTransaction.FirstOrDefault().Date.Year.ToString();
                    if (grpByMonthTransaction.Sum(x => x.Amount) > 100)
                    {
                        rewards.TotalPoints = (Convert.ToInt32(grpByMonthTransaction.Sum(x => x.Amount)) - 100) * 2+50;
                    }
                    else if( grpByMonthTransaction.Sum(x => x.Amount) >50 && grpByMonthTransaction.Sum(x => x.Amount) <= 100 )
                    {
                        rewards.TotalPoints = 50;
                    }
                    else
                    {
                        rewards.TotalPoints = 0;
                    }
                    i++;
                    rewardPoints.Add(rewards);
                }
            }
          
            Console.WriteLine("Reward points of customer per Month");
            if (rewardPoints.Where(x => x.Name.ToLower() == Name && x.Month.ToLower() == Month && x.Year == Year).FirstOrDefault() != null)
            {
                Console.WriteLine("CustomerId: {2} , CustomerName : {0} , Total Points : {1}", rewardPoints.Where(x => x.Name.ToLower() == Name && x.Month.ToLower() == Month && x.Year == Year).FirstOrDefault().Name, rewardPoints.Where(x => x.Name.ToLower() == Name && x.Month.ToLower() == Month.ToLower() && x.Year == Year).FirstOrDefault().TotalPoints, rewardPoints.Where(x => x.Name.ToLower() == Name && x.Month.ToLower() == Month.ToLower() && x.Year == Year).FirstOrDefault().Id);
            }
            else
            {
                Console.WriteLine("Record Not Exist.");
            }
                         
            //foreach (var rewardPoint in rewardPoints.GroupBy(x=>x.Month))
            //{
            //    Console.WriteLine("Reward points earned for each customer per Month");
            //    Console.WriteLine("Month:-" +rewardPoint.FirstOrDefault().Month + " Year:-" + rewardPoint.FirstOrDefault().Year);
            //    foreach(var point in rewardPoint)
            //    {
            //        Console.WriteLine("CustomerId: {2} , CustomerName : {0} , Total Points : {1}", point.Name,point.TotalPoints,point.Id);
            //    }
            //}
        }

        public static List<Transactions> IntializePurchase()
        {

            List<Transactions> customers = new List<Transactions>();

            //June
            customers.Add(new Transactions { Name = "Liam", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Liam", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Liam", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Liam", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=30, Date=DateTime.ParseExact("06/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=40, Date=DateTime.ParseExact("06/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=50, Date=DateTime.ParseExact("06/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("06/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=30, Date=DateTime.ParseExact("06/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=40, Date=DateTime.ParseExact("06/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=50, Date=DateTime.ParseExact("06/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            //July
            customers.Add(new Transactions { Name = "Liam", Id = 1,Amount=15, Date=DateTime.ParseExact("07/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=24, Date=DateTime.ParseExact("07/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=32, Date=DateTime.ParseExact("07/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Noah", Id = 4,Amount=23, Date=DateTime.ParseExact("07/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Liam", Id = 1,Amount=27, Date=DateTime.ParseExact("07/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "James", Id = 2,Amount=23, Date=DateTime.ParseExact("07/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=40, Date=DateTime.ParseExact("07/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Noah", Id = 4,Amount=22, Date=DateTime.ParseExact("07/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Liam", Id = 1,Amount=21, Date=DateTime.ParseExact("07/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "James", Id = 2,Amount=29, Date=DateTime.ParseExact("07/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=40, Date=DateTime.ParseExact("07/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Noah", Id = 4,Amount=30, Date=DateTime.ParseExact("07/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("07/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "James", Id = 2,Amount=25, Date=DateTime.ParseExact("07/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=30, Date=DateTime.ParseExact("07/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Noah", Id = 4,Amount=19, Date=DateTime.ParseExact("07/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Liam", Id = 1,Amount=23, Date=DateTime.ParseExact("07/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "James", Id = 2,Amount=30, Date=DateTime.ParseExact("07/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=20, Date=DateTime.ParseExact("07/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=15, Date=DateTime.ParseExact("07/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            //August
            customers.Add(new Transactions { Name = "Liam", Id = 1,Amount=14, Date=DateTime.ParseExact("08/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=30, Date=DateTime.ParseExact("08/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=22, Date=DateTime.ParseExact("08/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=50, Date=DateTime.ParseExact("08/15/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("08/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=15, Date=DateTime.ParseExact("08/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=25, Date=DateTime.ParseExact("08/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=28, Date=DateTime.ParseExact("08/17/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("08/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=20, Date=DateTime.ParseExact("08/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "William", Id = 3,Amount=40, Date=DateTime.ParseExact("08/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=20, Date=DateTime.ParseExact("08/19/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("08/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "James", Id = 2,Amount=15, Date=DateTime.ParseExact("08/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=29, Date=DateTime.ParseExact("08/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Noah", Id = 4,Amount=25, Date=DateTime.ParseExact("08/21/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Liam", Id = 1,Amount=20, Date=DateTime.ParseExact("08/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "James", Id = 2,Amount=15, Date=DateTime.ParseExact("08/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "William", Id = 3,Amount=21, Date=DateTime.ParseExact("08/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Noah", Id = 4,Amount=50, Date=DateTime.ParseExact("08/25/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            return customers;
        }

    }
}
