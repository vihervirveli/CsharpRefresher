using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    internal class T4Palindrome
    {
        public static bool IsPalindrome(string sentence)
        {

            bool isPal = false;
            StringBuilder reverse = new StringBuilder();
            for (int i = sentence.Length - 1; i >= 0; i--)
            {
               reverse.Append(sentence[i]);
            }

            string possiblePalindrome = reverse.ToString();
            
            if (sentence == possiblePalindrome)
            {
                isPal = true;
            }
           
            return isPal;
        }


        static void Main(string[] args)
        {
            //Make a program that asks an end user for a sentence or string.
            //Create a static method for checking is the given sentence or
            //word palindrome or not. The method has one argument, and it
            //returns boolean value (true or false).  The program will show
            //the end user if the given string was a palindrome.
            try
            {

            
            Console.WriteLine("Give a sentence or string: ");
            string sentence = Console.ReadLine();
            bool sIsPalindrome = IsPalindrome(sentence);
            if (sIsPalindrome)
            {
                Console.WriteLine($"{sentence} is a palindrome");
            }
            else
            {
                Console.WriteLine($"{sentence} is not a palindrome");
            }

            Console.ReadKey();
            }
        
            catch (Exception)
            {
                Console.WriteLine("You didn't give a valid input. Try again.");
               
            }
        }//main
    }//class
}//namespace
