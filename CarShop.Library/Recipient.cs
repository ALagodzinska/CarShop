using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class Recipient
    {
        public Car Car { get; set; }
        public string RecipientId { get; set; }
        public string RecipientName { get; set; }
        public DateTime Date { get; set; }
    }
}
