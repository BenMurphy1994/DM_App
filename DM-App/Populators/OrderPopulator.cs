﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_App.Populators
{
    class OrderPopulator
    {
        public static void Populate()
        {
            int totalRows = Program.TotalRows;
            int chunkSize = Program.ChunkSize;

            for (int j = 0; j < totalRows; j += chunkSize)
            {
                using (var db = new DM_Model())
                {
                    var query = (from b in db.Orders
                                 orderby b.ID
                                 select b).Skip(j).Take(chunkSize);

                    //var results = query.ToList();

                    //for (int i = 0; i < chunkSize; i++)
                    //{
                    //    Mining row = new Mining
                    //    {
                    //        Order_Id = results[i].ID,
                    //        PricingCurrencyCode = results[i].PricingCurrencyCode,
                    //        TaxCurrencyCode = results[i].TaxCurrencyCode,
                    //        IssueDate = results[i].IssueDate,
                    //        AnticipatedMonetaryTotal_Id = results[i].AnticipatedMonetaryTotal_Id
                    //    };
                    //    db.Minings.Add(row);
                    //    Console.WriteLine($"Order Table: {j}, {i}");
                    //}

                    List<Mining> miningRows = db.Minings.ToList();

                    foreach (var item in query)
                    {
                        Mining rowUpdate = miningRows.Single(x => x.Order_Id == item.ID);
                        rowUpdate.AnticipatedMonetaryTotal_Id = item.AnticipatedMonetaryTotal_Id;
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
