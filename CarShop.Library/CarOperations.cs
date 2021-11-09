using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        //public List<Car> ListOfCars = new List<Car>();
        public Car[] CarArray = new Car[100];

        public void AddCarToTheList(Car car)
        {
            //ListOfCars.Add(car);
            var index = CarArray.Count(x => x != null);
            // add car
            CarArray[index] = car;
        }

        public int FindAvailableCarsCount()
        {
            return CarArray.Count(x => x != null && x.IsAvailable);
        }

        public Car[] FindCarByYear(int year)
        {
            return CarArray.Where(x => x != null && x.Year == year).ToArray();
        }
        public Car[] FindCarByColor(string color)
        {
            return CarArray.Where(x => x != null && x.Color == color).ToArray();
        }

        public Car BuyCar(int id)
        {
            var selectedCar = CarArray.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                selectedCar.Sold = true;
                selectedCar.IsAvailable = false;
            }

            return selectedCar;
        }

        public string GetReceipt(Car receiptCar)
        {
            var receipt = new Receipt();

            Console.WriteLine("Enter your name and surname: ");
            receipt.CustomerName = Console.ReadLine();

            Console.WriteLine("Enter your address(street,city,country): ");
            receipt.CustomerAddress = Console.ReadLine();

            bool wrongInput = true;
            while (wrongInput != false)
            {
                Console.WriteLine("Enter your phone number(Phone number pattern: +XXX YYYYYYYY):");
                var phoneNumber = Console.ReadLine();

                string pattern = "\\+\\d{3}\\s\\d{8}";
                var rgx = new Regex(pattern);
                if (rgx.IsMatch(phoneNumber))
                {
                    receipt.CustomerNumber = phoneNumber;
                    wrongInput = false;
                }
                else
                {
                    Console.WriteLine($"Phone number {phoneNumber} has wrong format");

                }
            }           

            string carModel = receiptCar.Model;
            string carModelForId = carModel.Substring(0, 2);
            receipt.Id = $"{carModelForId}-000{receiptCar.Id}";

            receipt.Date = DateTime.Now.ToString();

            Console.WriteLine("Enter quantity you are willing to buy: ");
            receipt.Qty = Convert.ToInt32(Console.ReadLine());
            receipt.Description = $"Car with {receiptCar.Id} id; {receiptCar.Model} model; {receiptCar.Year} year; {receiptCar.Color} color.";
            receipt.Total = receiptCar.Price * receipt.Qty;

            //Recepiet
            string printRecepiet = 
                    $"\n" +
                    $"Receipt\n\n" + 
                    $"Company name:\t\t{receipt.CompanyName}\n" +
                    $"Company address:\t{receipt.CompanyAddress}\n\n" +
                    $"Bill to:\t\t{receipt.CustomerName};{receipt.CustomerNumber}\n\n" +
                    $"Ship to:\t\t{receipt.CustomerAddress}\n\n" +                    
                    $"Receipt ID:\t\t{receipt.Id}\n" +
                    $"Date:\t\t\t{receipt.Date}\n\n" +
                    $"Qty\tDescription\t\t\t\t\t\t\tTotal price\n" +
                    $"_____________________________________________________________________________________\n" +
                    $"{receipt.Qty}\t{receipt.Description}\t\t{receipt.Total}\n\n";

            return printRecepiet;
        }        
    }    
}
