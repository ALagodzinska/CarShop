using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class Car 
    {        
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public bool IsAvailable => Convert.ToInt32(Year) > 2010;
    }
}
