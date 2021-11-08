using System;
using System.Linq;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        static readonly CarOperations CarOperator = new CarOperations();
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Model = "Toyota";
            car.Color = "Black";
            car.Year = 1998;

            Car car1 = new Car();
            car1.Model = "Audi";
            car1.Color = "White";
            car1.Year = 2012;

            Car car2 = new Car();
            car2.Model = "BMW";
            car2.Color = "Blue";
            car2.Year = 2020;

            CarOperator.CarArray[0] = car;
            CarOperator.CarArray[1] = car1;
            CarOperator.CarArray[2] = car2;

            ShowMenu();           


            string exit = "continue";

            while(exit == "continue")
            {
                string option = Console.ReadLine();

                if(option.Equals("exit"))
                {
                    exit = option;
                }

                switch(option)
                {
                    case "1":
                        //Add car to the list
                        AddCarToTheList();
                        break;
                    case "2":
                        //Find a car by criteria
                        FindCarByYear();
                        break;
                    case "3":
                        //Get available car
                        SeeAvailableCars();
                        break;
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please choose operation");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find car by criteria");
            Console.WriteLine("3. Get available cars");
            //Console.ReadLine();
        }
        public static Car CreateCarObject() //function with type Car, should return an object in the end
        {
            var car = new Car();

            Console.WriteLine("Please add car model:");
            car.Model = Console.ReadLine();

            Console.WriteLine("Add car color:");
            car.Color = Console.ReadLine();

            Console.WriteLine("Add car year:");
            car.Year = Convert.ToInt32(Console.ReadLine());

            return car;
        }

        public static void AddCarToTheList()
        {
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject();
                CarOperator.AddCarToTheList(car);

                Console.WriteLine("Do you want to create more cars?(Yes/No)");

                var yesNo = Console.ReadLine();
                if (yesNo != "Yes")
                {
                    continues = false;
                }
            }
        }
        public static void FindCarByYear()
        {            
            Console.WriteLine("Please enter a year:");
            var year = Convert.ToInt32(Console.ReadLine());
            
            var car = CarOperator.FindCar(year);
            if (car != null)
            {
                Console.WriteLine($"Found car: {car.Model}");
            }
            else
            {
                Console.WriteLine("No cars found");
            }
        }        
        public static void SeeAvailableCars()
        {
            Console.WriteLine($"Available cars count: {CarOperator.FindAvailableCarsCount()}");
            var count = CarOperator.CarArray.Count(x => x != null);
            Console.Write("Available cars: ");
            for (int i = 0; i < count; i++)
            {
                Car car = CarOperator.CarArray[i];  
                if(car.IsAvailable == true)
                {
                    Console.Write($"{car.Model}; ");
                }
            }
            Console.WriteLine();
        }

        //public static void AddCarToTheLIst()
        //{
        //    var car = CreateCarObject();
        //    var carOperator = new CarOperations(); //instance of the class

        //    carOperator.AddCarToTheList(car);
        //}        
    }
}
