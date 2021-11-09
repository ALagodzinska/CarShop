using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public interface ICarOperations
    {
        public void AddCarToTheList(Car car);
        public Car[] FindCarByYear(int year);
        public Car[] FindCarByColor(string color);
        public int FindAvailableCarsCount();
        public string GetReceipt(Car receiptCar);
        public Car BuyCar(int id);
    }
}