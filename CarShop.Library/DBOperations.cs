using CarShop.Library.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class DBOperations
    {
        public void CreateDbIfNotExsists()
        {
            using (var context = new CarDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
        public List<Car> GetCarList()
        {
            var cars = new List<Car>();
            using (var Context = new CarDbContext())
            {
                cars = Context.Cars.ToList();
            }

            return cars;
        }
        public void AddCarToTheList(Car car)
        {           
            using (var context = new CarDbContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }
        public void UpdateCarInfo(Car getCar)
        {
            using (var context = new CarDbContext())
            {
                getCar = context.Cars.FirstOrDefault(x => x.Id == getCar.Id);
                if (getCar != null)
                {
                    getCar.Sold = true;
                    getCar.IsAvailable = false;
                    context.Update(getCar);
                    context.SaveChanges();
                }
            }
        }
        public void AddCarReceiptToDb(Recipient reciept)
        {
            using (var context = new CarDbContext())
            {
                Car getCar = context.Cars.FirstOrDefault(x => x.Id == reciept.Car.Id);
                reciept.Car = getCar;

                context.Reciept.Add(reciept);
                context.SaveChanges();
            }
        }
    }
}

