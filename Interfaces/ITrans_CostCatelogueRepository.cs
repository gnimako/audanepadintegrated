using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_CostCatelogueRepository
    {
        Trans_CostCatelogue GetTrans_CostCatelogue(string Id);

		IEnumerable<Trans_CostCatelogue> GetAllTransCostCatelogue();
        Trans_CostCatelogue Add(Trans_CostCatelogue rec);
        Trans_CostCatelogue Update(Trans_CostCatelogue recChanges);
        Trans_CostCatelogue Delete(string id);
         
    }
}