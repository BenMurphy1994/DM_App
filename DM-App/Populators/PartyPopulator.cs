using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class PartyPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.Parties
                                 join t2 in db.Minings on t1.Order_Id equals t2.Order_Id
                                 orderby t1.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    var results = query.ToList();

                    List<Mining> miningRows = db.Minings.ToList();

                    for (int i = 0; i < chunkSize; i++)
                    {
                        Mining rowUpdate = miningRows.Single(x => x.Order_Id == results[i].Order_Id);
                        rowUpdate.PartyIdentification = results[i].PartyIdentification;
                        Console.WriteLine($"Party table: {j}, {i}");
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
