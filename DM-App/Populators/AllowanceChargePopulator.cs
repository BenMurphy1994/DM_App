using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class AllowanceChargePopulator
    {
        public static void Populate()
        {
            //int totalRows = Program.TotalRows;
            //int chunkSize = Program.ChunkSize;
            int totalRows = 1000000;
            int chunkSize = 10000;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.AllowanceCharges
                                 orderby t1.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        if (miningRows.Exists(x => x.Order_Id == item.Order_Id))
                        {
                            Mining rowUpdate = miningRows.Single(x => x.Order_Id == item.Order_Id);

                            //rowUpdate.AllowanceChargeReason = item.AllowanceChargeReason;
                            //rowUpdate.Amount_Value = item.Amount_Value;
                            rowUpdate.Price_Id = item.Price_Id;

                            Console.WriteLine($"AllowanceCharge table: {j}, {counter}");

                            counter++;
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
