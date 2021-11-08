using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        //static readonly Car car = new Car();
        //private List<Car> ListOfCars = new List<Car>();
        public Car[] CarArray = new Car[100];

        public void AddCarToTheList(Car car)
        {
            var count = CarArray.Count(x => x != null);
            CarArray[count] = car;
            //ListOfCars.Add(car);
        }

        public int FindAvailableCarsCount()
        {            
            var count = CarArray.Count(x => x != null && x.IsAvailable);
            return count;
        }

        public Car FindCar(int year)
        {
            var count = CarArray.Count(x => x != null);
            for(int i = 0; i < count; i++)
            {
                Car car = CarArray[i];

                bool TrueOrFalse = car.Year == year;
                if (TrueOrFalse == true)
                {
                    return car;
                }
            }            
            return null;
        }
        //public Car FindCar(int year)
        //{    
        //    //var SearchByYear = ListOfCars.Find(car => car.Year == year);
        //    //return SearchByYear;
        //}

        public string GetRecipiet()
        {
            return null;
        }
    }
}
