using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class Car
    {
        private bool isAvailable;

        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }
        public bool IsAvailable
        {
            get => Convert.ToInt32(Year) > 2010;
            set => isAvailable = value;
        }
    }
}