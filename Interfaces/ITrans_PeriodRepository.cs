using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_PeriodRepository
    {
        Trans_Period GetRecord (string Id);

		IEnumerable<Trans_Period> GetAllRecords();
		Trans_Period Add(Trans_Period rec);
		Trans_Period Update(Trans_Period recChanges);
		Trans_Period Delete(string id);
         
    }
}