using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class OrderLineExtensionPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.OrderLineExtensions
                                 join t2 in db.Minings on t1.OrderLine_Id equals t2.OrderLineAlias
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        if (miningRows.Exists(x => x.OrderLineAlias == item.OrderLine_Id))
                        {
                            Mining rowUpdate = miningRows.Single(x => x.OrderLineAlias == item.OrderLine_Id);

                            rowUpdate.IsSubscription = item.IsSubscription;
                            rowUpdate.SubscriptionFrequency = item.SubscriptionFrequency;

                            Console.WriteLine($"OrderLineExtensions table: {j}, {counter}");

                            counter++;
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
