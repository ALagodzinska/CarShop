using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public static class UserOutput
    {
        public static void FindAvailableCarMessage(int count)
        {
            Console.WriteLine($"Available car count is: {count}");
        }

        public static void CongratulationMessage(string model)
        {
            Console.WriteLine(
                $"Congratulation with purchasing car : " +
                $"{model}. Would you like to have receipt(Yes/No)?");
        }

        public static void ReceiptMessage(string receiptData)
        {
            Console.WriteLine(receiptData);
        }

        public static void NoCarWithIdMessage(int id)
        {
            Console.WriteLine($"There is not car with id: {id}");
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please choose car operation:");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find car by is available");
            Console.WriteLine("3. Find car by year");
            Console.WriteLine("4. Show list of all presented cars");
            Console.WriteLine("5. Buy a car");
        }

        public static void ChooseModelMessage()
        {
            Console.WriteLine("Please add car model:");
        }

        public static void ChooseColorMessage()
        {
            Console.WriteLine("Add car color");
        }

        public static void ChooseYearMessage()
        {
            Console.WriteLine("Add car year");
        }

        public static void ChooseIdMessage()
        {
            Console.WriteLine("Please add car id:");
        }

        public static void DoYouWantToAddMoreCarsMessage()
        {
            Console.WriteLine("Do you want to create more cars?(Yes/No)");
        }

        public static void ProvideYearMessage()
        {
            Console.WriteLine("Please provide year");
        }

        public static void FoundCarMessage(int id, string model)
        {
            Console.WriteLine($"Found car Id: {id} model: {model}");
        }

        public static void ShowListOfCarsMessage(int id, string model, int i)
        {
            Console.WriteLine($"{i}. Car with {id} model: {model}");
        }

        public static void ProvideCarIdMessage()
        {
            Console.WriteLine("Please provide car id from the car list");
        }
    }
}