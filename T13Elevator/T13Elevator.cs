using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T13Elevator
{
    public class Elevator
    {
        private int floor = 1;
        public int Floor
        {
            get { return floor; }
            set
            {
                bool under = value > 0;
                bool over = value < 6;
                if (under  && over)
                {
                    floor = value;
                }//if
                 else
                {
                    if (under)
                    {
                        AnnounceTooSmall();
                    }
                }
            }//set
        }//accessor

        public string AnnounceTooSmall()
        {
            return "Your floor was too small!";
        }
        

    }
    internal class T13Elevator
    {
        static void Main(string[] args)
        {

        }
    }
}
