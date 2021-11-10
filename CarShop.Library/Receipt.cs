using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class Receipt
    {
        public string CompanyName = "CarSale";
        public string CompanyAddress = "2326 Peck Street, London, UK";

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNumber { get; set; }        
        public string Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }                   
        public int Total { get; set; }
        public void printReceipt()
        {
            string printRecepiet =
                    $"\n" +
                    $"Receipt\n\n" +
                    $"Company name:\t\t{CompanyName}\n" +
                    $"Company address:\t{CompanyAddress}\n\n" +
                    $"Bill to:\t\t{CustomerName};{CustomerNumber}\n\n" +
                    $"Ship to:\t\t{CustomerAddress}\n\n" +
                    $"Receipt ID:\t\t{Id}\n" +
                    $"Date:\t\t\t{Date}\n\n" +
                    $"Description\t\t\t\t\t\t\tTotal price\n" +
                    $"____________________________________________________________________________\n" +
                    $"{Description}\t\t{Total}\n\n";

            Console.WriteLine(printRecepiet);
        }
    }
}
