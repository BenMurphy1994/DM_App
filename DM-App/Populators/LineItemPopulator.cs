using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class LineItemPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.LineItems
                                 join t2 in db.Minings on t1.Alias equals t2.PostalAddress_Id
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in query)
                    {
                        //if (miningRows.Exists(x => x.PostalAddress_Id == item.Alias - 1))
                        //{
                            Mining rowUpdate = miningRows.Single(x => x.PostalAddress_Id == item.Alias - 1);

                            rowUpdate.Quantity = item.Quantity;
                            rowUpdate.Item_AdditionalInformation = item.Item_AdditionalInformation;
                            rowUpdate.Item_Code = item.Item_Code;
                            rowUpdate.Item_Type = item.Item_Type;

                            Console.WriteLine($"LineItem table: {j}, {counter}");

                            counter++;
                        //}
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
