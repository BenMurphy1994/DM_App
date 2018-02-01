using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class OrderLinePopulator
    {
        public static void Populate()
        {
            //int totalRows = Program.TotalRows;
            //int chunkSize = Program.ChunkSize;
            int totalRows = 25000;
            int chunkSize = 5000;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.OrderLines
                                 join t2 in db.Minings on t1.Order_Id equals t2.Order_Id
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        if (miningRows.Exists(x => x.Order_Id == item.Order_Id))
                        {
                            Mining rowUpdate = miningRows.Single(x => x.Order_Id == item.Order_Id);

                            rowUpdate.OrderLineAlias = item.Alias;

                            Console.WriteLine($"OrderLine table: {j}, {counter}");

                            counter++;
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
