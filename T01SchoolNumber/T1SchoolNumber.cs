using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    internal class T1SchoolNumber
    {

        static void Main(string[] args)
        {
            //Make a program that gives the student a grade according to the following table,
            //the score is asked and the program prints the number. Check that the given
            //value is a number, and give an appropriate error message if it is not.
            int[] gradeLimits = {0, 20, 30, 40, 50, 60 };
            Console.WriteLine("Give points: ");
            string pointsString = Console.ReadLine();
            try
            {
                int points = Int32.Parse(pointsString);
                int grade = 0;
                for (int i = 0; i < gradeLimits.Length; i++)
                {
                    if (gradeLimits[i] <= points)
                    {
                        grade = i;
                    }
                }

                Console.WriteLine($"Your grade is {grade}");
                Console.ReadLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error, you didn't give a valid integer number. You can read the error message below: ");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            
            
        }
    }
}
