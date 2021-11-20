using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        private const string TargetPath = @"C:\Users\anast\source\repos\CarShop1\SchoolFiles";
        private const string TextFile = @"C:\Users\anast\source\repos\CarShop1\SchoolFiles\CarData.txt";

        public void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }
        }
        public void CreateFileIfNotExists()
        {
            if (!File.Exists(TextFile))
            {
                File.Create(TextFile);
            }
        }
        public List<Car> GetCarList()
        {
            List<Car> ListOfCars = new List<Car>();
            char[] spearator = { ',' };
            var carInfo = File.ReadLines(TextFile);
            foreach (var line in carInfo)
            {
                String[] strlist = line.Split(spearator).ToArray();
                var car = new Car()
                {
                    Id = Convert.ToInt32(strlist[0]),
                    Model = strlist[1],
                    Color = strlist[2],
                    Year = Convert.ToInt32(strlist[3]),
                    IsAvailable = Convert.ToBoolean(strlist[4])
                };
                ListOfCars.Add(car);
            }
            return ListOfCars;
        }
        public void AddCarToTheTextFile(Car car)
        {
            string[] carInfo = new string[5];

            carInfo[0] = car.Id.ToString();
            carInfo[1] = car.Model;
            carInfo[2] = car.Color;
            carInfo[3] = car.Year.ToString();
            carInfo[4] = (car.IsAvailable).ToString();

            var stringContent = String.Join(',', carInfo);

            using (StreamWriter streamWriter = File.AppendText(TextFile))
            {
                streamWriter.WriteLine(stringContent);
            }
        }
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
                selectedCar.Sold = true;
                selectedCar.IsAvailable = false;

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
