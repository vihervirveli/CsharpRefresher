using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int TireCount { get; set; }
        public int Speed { get; set; }

        public Vehicle(string brand, string model, int tires, int speed)
        {
            Brand = brand;
            Model = model;
            Speed = speed;
            TireCount = tires;
        }

        public string ShowInfo()
        {
            return $"This vehicle's manufacturer is {Brand} and its model is {Model}";
        }
        public override string ToString()
        {
            return $"This vehicle's manufacturer is {Brand}, its model is {Model}, it has {TireCount} tires and is going {Speed} km/h";
        }

    } //Vehicle class


    internal class T9Vehicle
    {

        public static void TestT9()
        {
            Vehicle car1 = new Vehicle("Toyota", "Corolla", 4, 50);
            Console.WriteLine(car1.ShowInfo());
            Console.WriteLine(car1);
            Console.WriteLine("Changing the car's properties:");
            car1.Speed = 100;
            car1.Model = "Avalon";
            Console.WriteLine(car1.ShowInfo());
            Console.WriteLine(car1);

            Console.WriteLine();
            Vehicle car2 = new Vehicle("Peugeot", "208 GTI", 3, 80);
            Console.WriteLine(car2.ShowInfo());
            Console.WriteLine(car2);
            Console.WriteLine("Changing the car's properties:");
            car2.Speed = 120;
            car2.TireCount = 4;
            car2.Model = "3008 SUV";
            Console.WriteLine(car2.ShowInfo());
            Console.WriteLine(car2);
            Console.WriteLine();
            Vehicle bike = new Vehicle("Helkama", "Kaunotar", 2, 10);
            Console.WriteLine(bike.ShowInfo());
            Console.WriteLine(bike);
            Console.WriteLine("Changing the bike's properties:");
            bike.Speed = 15;
            bike.Model = "Velhotar";
            bike.TireCount = 1;
            Console.WriteLine(bike.ShowInfo());
            Console.WriteLine(bike);

        }
        static void Main(string[] args)
        {
            TestT9();
            Console.ReadKey();
        }
    }
}
