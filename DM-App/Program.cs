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
            //Populators.OrderPopulator.Populate();
            //Populators.PartyPopulator.Populate();
            //Populators.AddressPopulator.Populate(); 

            // Little bit janky: 
            //Populators.OrderLinePopulator.Populate();

            // This one's janky and takes 6m to run on it's own:
            //Populators.AllowanceChargePopulator.Populate();

            //TODO: Populators.LineItemPopulator.Populate();

            //Populators.MonetaryTotalPopulator.Populate();

            //TODO: Price_Id is null so the relationship isn't possible? 
            //Populators.PricePopulator.Populate();
            Populators.OrderLineExtensionPopulator.Populate();

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

