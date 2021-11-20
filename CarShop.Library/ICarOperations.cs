using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public interface ICarOperations
    {
        public Car[] FindCarByYear(int year);
        public void FindAvailableCarsCount();
        public string GetReceipt(Car car);
        public void ByCar(int id);
    }
}