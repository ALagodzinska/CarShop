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
        public Car FindCar(int year);
        public int FindAvailableCarsCount();
        public string GetRecipiet();
    }
}
