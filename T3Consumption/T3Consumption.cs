using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    internal class T3Consumption
    {
        /// <summary>
        /// Calculates the amount of gasoline consumed and the cost of the gasoline spent.
        /// Fuel price and consumption are randomized.
        /// </summary>
        /// <param name="kilometers">How many kilometers the trip took</param>
        /// <returns></returns>
        public static double CalculateConsumption(double kilometers, out double euros)
        {
            double[] gasAndCost = new double[2];
            Random r = new Random();
            double lowGas = 1.75;
            double highGas = 2.51; //includes 2.50
            double gasPrice = r.NextDouble() * (highGas - lowGas) + lowGas;
            double lowConsumption = 6.0;
            double highConsumption = 9.1; //includes 9.0
            // consumption 6-9 liters / 100km
            double consumptionPer100km = r.NextDouble() * (highConsumption - lowConsumption) + lowConsumption;
            double consumption = (consumptionPer100km * kilometers) / 100;
            euros = consumption * gasPrice;
            
            return consumption;
        }

        
       public static void Main(string[] args)
        {
            //Create a static method to calculate the cost of a certain trip.
            //In the main program the user is asked for the distance driven,
            //check that the given input is a number. After that, the main
            //program calls the method sending the number of kilometers
            //driven as a parameter.The method draws randomly consumption
            //between 6 - 9 liters / 100km.The fuel price is randomly
            //selevted between 1, 75 - 2, 50€ per litre.
            //The method returns the amount of gasoline consumed and the
            //amount of money spent on gasoline, the main program shows them to the user.

            Console.WriteLine("Enter distance traveled: ");
            string distancestr = Console.ReadLine();
            try
            {
                double distance = 0;
                if (double.TryParse(distancestr, out distance))
                {
                    double consumption = CalculateConsumption(distance, out double euro);
                    Console.WriteLine($"The amount of gasoline consumed was {consumption:0.00} liters");
                    Console.WriteLine($"The amount of money spent on gasoline was {euro:0.00} euros");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You did not input a number when asked for distance.");
                    Console.ReadKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("You did not input a number when asked for distance. Read the error message below.");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }


        }
    }

 
}
