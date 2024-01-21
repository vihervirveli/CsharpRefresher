using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public class WashingMachine
    {
        public enum States
        {
            StandBy,
            LoadInProgress,
            FinishedAndBleeping,
        }//enum

        private Boolean powerOn = false;
        private States state = States.StandBy;
        private double quantityOfPowder = 0F;
        private const double minimumPowder = 50F;
        private Boolean enoughPowder = false;
        public Boolean PowerOn
        {
            get { return powerOn; }
            set
            {
                powerOn = value;
            }
        }
        public States State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public double QuantityOfPowder
        {
            get { return quantityOfPowder; }
            set
            {
                quantityOfPowder = value;
                if (quantityOfPowder >= minimumPowder)
                {
                    enoughPowder = true;
                }
            }
        }

        public Boolean EnoughPowder
        {
            get { return enoughPowder; 
            }
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public WashingMachine()
        {

        }
        /// <summary>
        /// Constructor with 1 parameter, indicating whether the machine is on
        /// </summary>
        /// <param name="powerOn"></param>
        public WashingMachine(bool powerOn)
        {
            this.powerOn = powerOn;
        }

        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="powerOn">Indicates whether the power is on</param>
        /// <param name="quantityOfPowder">tells how much powder the machine has inside it</param>
        public WashingMachine(bool powerOn, double quantityOfPowder)
        {
            this.powerOn = powerOn;
            this.quantityOfPowder = quantityOfPowder;
        }

        /// <summary>
        /// Returns either an indication of not being able to wash the load for whatever reason, or 
        /// a successfully returns the output of washing the load
        /// </summary>
        /// <returns>The output of the load</returns>
        public string PutALoadOn()
        {
            if (powerOn == false || enoughPowder == false)
            {
                return $"The washing machine either wasn't turned on or you didn't have enough powder to wash your clothes. Please either turn on the machine or administer more powder and try again";

            }
            state = States.LoadInProgress;
            quantityOfPowder -= 50;
            string loadOutPut = $"The washing machine had enough powder, and it is now washing the load. The remaining amount of powder after the wash is ${quantityOfPowder}";
            for (int i = 0; i < 3; i++)
            {
                string cyclePhase = "\nWashing...";
                loadOutPut += cyclePhase;

            }
            state = States.FinishedAndBleeping;
            loadOutPut += "\nYour cycle is finished. The machine is bleeping to indicate your laundry is done.";
            state = States.StandBy;
            return loadOutPut;
        }

    } //WashingMachine class

    internal class T7WashingMachine
    {
        /// <summary>
        /// Creates a WashingMachine object based on the given specs
        /// </summary>
        /// <param name="constructorType">0 is no parameter constructor, 1 is 1 parameter (powerIsOn) and 2 is (powderAmount and powerIsOn)</param>
        /// <param name="powderAmount"></param>
        /// <param name="powerIsOn"></param>
        public static void TestT7(int constructorType, double powderAmount, Boolean powerIsOn )
        {
            WashingMachine washingMachine;
            if (constructorType == 0)
            {
                washingMachine = new WashingMachine();
            }
            else if (constructorType == 1)
            {
                washingMachine = new WashingMachine(powerIsOn);
            }
            else
            {
                washingMachine = new WashingMachine(powerIsOn, powderAmount);
            }
            washingMachine.QuantityOfPowder = powderAmount;
            string load = washingMachine.PutALoadOn();
            Console.WriteLine($"{load}");
        }

        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Exampe of a succesful test");
            TestT7(2, 65.5, true);
            Console.WriteLine();
            Console.WriteLine("Exampe of another succesful test");
            TestT7(1, 55.5, true);
            Console.WriteLine();
            Console.WriteLine("Exampe of a failed test");
            TestT7(0, 3.5, false);
            Console.ReadKey();
        }
    }
}
