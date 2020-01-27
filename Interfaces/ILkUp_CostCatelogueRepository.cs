using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_CostCatelogueRepository
    {
        LkUp_CostCatelogue GetCostCatelogue(int Id);

		IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByCostCode(string code);
		IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByCostCategory(string category);
		IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByDescriptionExpression(string expression);

		IEnumerable<LkUp_CostCatelogue> GetAllCostCatelogue();
		LkUp_CostCatelogue Add(LkUp_CostCatelogue rec);
	    LkUp_CostCatelogue Update(LkUp_CostCatelogue recChanges);
		LkUp_CostCatelogue Delete(int id);
         
    }
}