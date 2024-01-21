using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public struct PeopleData
    {
        public string Name;
        public int YearOfBirth;
        public PeopleData(string name, int year)
        {
            Name = name; 
            YearOfBirth = year;
        }

        public string Show() { 
            return $"{Name} is {DateTime.Now.Year-YearOfBirth}"; 
        }

    }
    internal class T5Names
    {
        static void Main(string[] args)
        {
            //Make a program that asks the user for people's names and their year of birth.
            //Name and Year of Birth are separated by a comma. Entering names is finished by
            //entering an empty entry. Create a struct to save and present people's data.
            //After this, the program tells how many names were given and
            //displays them in order of age from youngest to oldest.
            List<PeopleData> datas = new List<PeopleData>();
            while (true)
            {
                Console.WriteLine("Please, give the names and the birth years of people. Empty input will stop the input.");
                Console.WriteLine("Give a name in the format 'name, year of birth'. Example: Maarit, 1989: ");
                string input = Console.ReadLine();
                if (input.Length== 0)
                {
                    break;
                }
                try
                {
                    string[] records = input.Split(',');
                    
                    for (int i = 0; i< records.Length; i++)
                    {
                        records[i] = records[i].Trim();
                      
                       
                    }

                    int year = 0;
                    if (int.TryParse(records[1], out year))
                    {
                       
                        PeopleData data = new PeopleData(records[0], year);
                        datas.Add(data);
                       
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Error, incorrect input");
                    continue;

                }
               
            }//while

            int currentYear = DateTime.Now.Year;
            datas.Sort((data1, data2) => (currentYear - data1.YearOfBirth).CompareTo(currentYear - data2.YearOfBirth));
            Console.WriteLine($"{datas.Count} names are given:");
            
            for (int i = 0; i < datas.Count; i++)
            {
                Console.WriteLine(datas[i].Show());
            }
            Console.ReadKey();
        } //main
    }//class
  
}//namespace
