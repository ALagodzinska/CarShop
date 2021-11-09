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
        public int Qty { get; set; }
        public string Description { get; set; }                   
        public int Total { get; set; }


    }
}
