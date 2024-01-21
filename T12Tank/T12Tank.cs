using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public class Tank
    {
        private int crewNumber = 4;
        private const float speedMax = 100;
        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber
        {
            get { return crewNumber; }
            set
            {
                if (value > 1 && value < 7)
                {
                    crewNumber = value;
                }//if
            }//set
        }//CrewNumber
        public float Speed { get; private set; }
        public float SpeedMax { get { return speedMax; } }

        public void AccelerateTo(float speed)
        {
            if (speed <= speedMax && speed >= 0)
            { Speed = speed; }

        }
        public void SlowTo(float speed)
        {
            if (speed <= speedMax && speed >= 0)
            { Speed = speed; }
        }

        public override string ToString()
        {
            return $"{Name} is a type {Type} tank, and it has {CrewNumber} crew members, and is going at speed {Speed}";
        }

    }//Tank class
    internal class T12Tank
    {
        public static void TestTank()
        {
            Tank testTank = new Tank();
            testTank.Name= "Tankster";
            testTank.Type = "T001-390";
            Console.WriteLine(testTank);
            testTank.AccelerateTo(84);
            Console.WriteLine(testTank);
            Console.WriteLine("Trying to accelerate to 130");
            testTank.AccelerateTo(130);
            Console.WriteLine(testTank);
            Console.WriteLine("Trying to slow to 30");
            testTank.SlowTo(30);
            Console.WriteLine("Trying to slow to -100");
            testTank.SlowTo(-100);
            Console.WriteLine(testTank);
            Console.WriteLine("Two crew members die");
            testTank.CrewNumber = 2;
            Console.WriteLine(testTank);
            Console.WriteLine("1 more crew member tries to leave (but won't)");
            testTank.CrewNumber = 1;
            testTank.Name = "Tankster 2";
            testTank.Type = "T002-3024";
            Console.WriteLine(testTank);

        }
        static void Main(string[] args)
        {
            TestTank();
            Console.ReadKey();

        }
    }
}
