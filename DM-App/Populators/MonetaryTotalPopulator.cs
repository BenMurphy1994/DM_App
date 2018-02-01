using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class MonetaryTotalPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.MonetaryTotals
                                 join t2 in db.Minings on t1.Alias equals t2.AnticipatedMonetaryTotal_Id
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        Mining rowUpdate = miningRows.Single(x => x.AnticipatedMonetaryTotal_Id == item.Alias);
                        rowUpdate.PayableAmount_Value = item.PayableAmount_Value;
                        rowUpdate.TaxInclusiveAmount_Value = item.TaxInclusiveAmount_Value;
                        Console.WriteLine($"MonetaryTotal table: {j}, {counter}");
                        counter++;
                    }

                    db.SaveChanges();
                }                
            }
        }
    }
}
