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
        public int Price 
        {
            get 
            {
                if (Year < 2005)
                {
                    return 5000;
                }
                else if (Year > 2005 && Year < 2015)
                {
                    return 10000;
                }
                else
                {
                    return 15000;
                }
            }
        }
    }
}
