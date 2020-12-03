using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_BarCodeIdentsRepository
    {
        WP_BarCodeIdents GetRecord (string Id);

        WP_BarCodeIdents GetRecordByDispatchCycle (string cycleid);

		IEnumerable<WP_BarCodeIdents> GetAllRecords();
		WP_BarCodeIdents Add(WP_BarCodeIdents rec);
		WP_BarCodeIdents Update(WP_BarCodeIdents recChanges);
		WP_BarCodeIdents Delete(string id);
         
    }
}