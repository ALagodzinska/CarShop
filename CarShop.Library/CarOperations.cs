using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarShop.Library
{
    public class CarOperations : DBOperations, ICarOperations
    {        
        public void FindAvailableCarsCount()
        {
            var count = GetCarList().Count(x => x != null && x.IsAvailable == true);
            UserOutput.FindAvailableCarMessage(count);
        }

        public Car[] FindCarByYear(int year)
        {
            var carList = GetCarList().Where(x => x != null && x.Year == year);

            return carList.ToArray();
        }

        public void ByCar(int id)
        {
            var selectedCar = GetCarList().FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                UpdateCarInfo(selectedCar);

                UserOutput.CongratulationMessage(selectedCar.Model);
            }
            else
            {
                UserOutput.NoCarWithIdMessage(id);
            }
        }

        public string GetReceipt(Car car)
        {
            var receipt = new Recipient()
            {
                Car = car,
                Date = DateTime.Now,
                RecipientId = Guid.NewGuid().ToString(),
                RecipientName = "Car selling receipt"
            };

            AddCarReceiptToDb(receipt);

            return @$"
                        Receipt number: {receipt.RecipientId}
                        Receipt name: {receipt.RecipientName}
                        Model: {receipt.Car.Model}
                        Year:  {receipt.Car.Year}
                        Color: {receipt.Car.Color}
                        Date:  {receipt.Date.Date}
                    ";
        }

        public void GetCarByYear(int year)
        {
            var carArray = FindCarByYear(year);

            foreach (var car in carArray)
            {
                UserOutput.FoundCarMessage(car.Id, car.Model);
            }
        }

        public void ShowListOfAllCars()
        {
            var i = 0;

            foreach (var car in GetCarList())
            {
                if (car != null)
                {
                    UserOutput.ShowListOfCarsMessage(car.Id, car.Model, i);
                }

                i++;
            }
        }
    }
}
