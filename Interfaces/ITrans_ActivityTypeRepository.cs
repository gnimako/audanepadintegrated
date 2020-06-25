using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ActivityTypeRepository
    {
        Trans_ActivityType GetTrans_ActivityType(string Id);

		IEnumerable<Trans_ActivityType> GetAllTransActivityType();
        Trans_ActivityType Add(Trans_ActivityType rec);
        Trans_ActivityType Update(Trans_ActivityType recChanges);
        Trans_ActivityType Delete(string id);
         
    }
}