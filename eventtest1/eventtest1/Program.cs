using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventtest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Incrementer incrementer = new Incrementer();
            Dozen dozensCounter = new Dozen(incrementer);
            incrementer.DoCount();
            Console.WriteLine("Number of Dozens = {0}", dozensCounter.DozensCount);
        }
    }

    delegate void Handler();

    class Incrementer
    {
        public event Handler CountedADozen;

        public void DoCount()
        {
            for (int i = 0; i < 120; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    CountedADozen();
                }
            }
        }
    }

    class Dozen
    {
        public int DozensCount { get; private set; }
        public Dozen(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDozensCount;

        }

        private void IncrementDozensCount()
        {
            DozensCount++;
            Console.WriteLine("Increment dozen: result = {0}", DozensCount);
        }
    }


}
