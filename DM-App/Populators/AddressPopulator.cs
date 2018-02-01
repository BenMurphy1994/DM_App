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
                                 join t2 in db.Minings on t1.Alias equals ((t2.PostalAddress_Id) - 1)
                                 where t1.CityName != null
                                 orderby t2.Order_Id
                                 select t1).Skip(j).Take(chunkSize);

                    // Due to the way the database is designed, the PostalAddress_Id doesn't exactly match the Alias
                    // so you have to -1 in the query and then add it back on in the foreach loop to match it up.

                    var results = query.ToList();

                    List<Mining> miningRows = db.Minings.ToList();

                    int counter = 0;

                    foreach (var item in results)
                    {
                        if(miningRows.Exists(x => (x.PostalAddress_Id == ((item.Alias) + 1))))
                        {
                            Mining rowUpdate = miningRows.Single(x => x.PostalAddress_Id == ((item.Alias) + 1));
                            
                            rowUpdate.CityName = item.CityName;
                            rowUpdate.Country = item.Country;
                            rowUpdate.CountrySubentity = item.CountrySubentity;
                            rowUpdate.PostalZone = item.PostalZone;

                            Console.WriteLine($"Address table: {j}, {counter}");

                            counter++;
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
