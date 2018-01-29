using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class AddressPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from t1 in db.Addresses
                                 join t2 in db.Minings on t1.Alias equals t2.PostalAddress_Id
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    var results = query.ToList();

                    List<Mining> miningRows = db.Minings.ToList();

                    for (int i = 0; i < chunkSize; i++)
                    {
                        Mining rowUpdate = miningRows.Single(x => x.PostalAddress_Id == results[i].Alias);

                        rowUpdate.CityName = results[i].CityName;
                        rowUpdate.Country = results[i].Country;
                        rowUpdate.CountrySubentity = results[i].CountrySubentity;
                        rowUpdate.PostalZone = results[i].PostalZone;

                        Console.WriteLine($"Address table: {j}, {i}");
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
