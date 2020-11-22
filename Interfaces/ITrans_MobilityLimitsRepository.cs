using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_MobilityLimitsRepository
    {
        Trans_MobilityLimits GetRecord (string Id);
        Trans_MobilityLimits GetFirstOrDefaultRecordSet ();

		IEnumerable<Trans_MobilityLimits> GetAllRecords();
		Trans_MobilityLimits Add(Trans_MobilityLimits rec);
		Trans_MobilityLimits Update(Trans_MobilityLimits recChanges);
		Trans_MobilityLimits Delete(string id);
         
    }
}