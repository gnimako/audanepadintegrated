using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ActivityTypeRepository
    {
        LkUp_ActivityType GetActivityType(int Id);

        LkUp_ActivityType GetActivityTypeByName(string name);
		IEnumerable<LkUp_ActivityType> GetAllActivityType();
        LkUp_ActivityType Add(LkUp_ActivityType atype);
        LkUp_ActivityType Update(LkUp_ActivityType atypeChanges);
        LkUp_ActivityType Delete(int id);
         
    }
}