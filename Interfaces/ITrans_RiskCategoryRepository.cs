using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_RiskCategoryRepository
    {
        Trans_RiskCategory GetRecord (string Id);

		IEnumerable<Trans_RiskCategory> GetAllRecords();
		Trans_RiskCategory Add(Trans_RiskCategory rec);
		Trans_RiskCategory Update(Trans_RiskCategory recChanges);
		Trans_RiskCategory Delete(string id);
         
    }
}