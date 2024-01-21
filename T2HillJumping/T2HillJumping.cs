using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    internal class T2HillJumping
    {
        static void Main(string[] args)
        {
            //Five judges are used in hill jumping. Write a program that asks rating points
            //for one jump and prints the sum of the style points such that the smallest and
            //largest style point has been subtracted from the sum.
            //Save the given numbers to an arrayt. Check that the given input is a number.
            int[] points = new int[5];
            try
            {
                for (int i = 0; i < 5; i++)
                {

                    Console.WriteLine("Give points: ");
                    string input = Console.ReadLine();
                    int point = Int32.Parse(input);
                    points[i] = point;
                }//for


                int maximum = points.Max();
                int minimum = points.Min();
                
                int sumtotal = points.Sum();
                int stylepoints = sumtotal - (maximum + minimum);
                Console.WriteLine($"Your overall style points are {stylepoints}");
                Console.ReadKey();
            }//try
            catch (FormatException e)
            {

                Console.WriteLine("You gave a value that was not an integer. Please read the error message below");
                Console.WriteLine(e.Message);
                Console.ReadKey();

            }//catch

        }//main
    }
}
