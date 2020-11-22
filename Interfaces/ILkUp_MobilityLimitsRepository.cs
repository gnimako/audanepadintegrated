using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_MobilityLimitsRepository
    {
        LkUp_MobilityLimits GetRecord(int Id);

        IEnumerable<LkUp_MobilityLimits> GetAllRecords();
        LkUp_MobilityLimits Add(LkUp_MobilityLimits atype);
        LkUp_MobilityLimits Update(LkUp_MobilityLimits atypeChanges);
        LkUp_MobilityLimits Delete(int id);
         
    }
}