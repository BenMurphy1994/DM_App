using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class PricePopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.Prices
                                 join t2 in db.Minings on t1.Alias equals t2.Price_Id
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        if (miningRows.Exists(x => x.Price_Id == item.Alias))
                        {
                            Mining rowUpdate = miningRows.Single(x => x.Price_Id == item.Alias);

                            rowUpdate.BaseQuantity = item.BaseQuantity;
                            rowUpdate.PriceAmount_Value = item.PriceAmount_Value;

                            Console.WriteLine($"Price table: {j}, {counter}");

                            counter++;
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
