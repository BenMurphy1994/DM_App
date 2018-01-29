using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App
{
    class Program
    {
        public static int TotalRows = 10000;
        public static int ChunkSize = 1000;
        static void Main(string[] args)
        {
            //Start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // Populators
            Populators.OrderPopulator.Populate();
            Populators.PartyPopulator.Populate();

            //Stop stopwatch
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            string timeTaken = $"{timespan.Minutes}m {timespan.Seconds}s";

            // Timing report and end program
            Console.WriteLine($"Done (in {timeTaken}). Press any key to exit...");
            Console.ReadLine();
        }
    }
}

