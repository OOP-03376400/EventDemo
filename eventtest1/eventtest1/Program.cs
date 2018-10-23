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

    public class IncrementerEventArgs : EventArgs
    {
        public int IterationCount { get; set; }
    }


    class Incrementer
    {
        public event EventHandler<IncrementerEventArgs>    CountedADozen;

        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs();

            for (int i = 0; i < 120; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    args.IterationCount = i;
                    CountedADozen(this, args);
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

        private void IncrementDozensCount(object source, IncrementerEventArgs e)
        {
            DozensCount++;
            Console.WriteLine("Increment at iteration {0} in {1}", e.IterationCount, source.ToString());
        }
    }


}
