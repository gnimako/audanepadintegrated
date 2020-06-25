using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DivHeadRepository
    {
        Struc_DivHead GetRecord (string Id);

		IEnumerable<Struc_DivHead> GetAllRecords();

        IEnumerable<Struc_DivHead> GetAllRecordsByDivision(int Division_Id);
        Struc_DivHead GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id);
		Struc_DivHead Add(Struc_DivHead rec);
		Struc_DivHead Update(Struc_DivHead recChanges);
		Struc_DivHead Delete(string id);
         
    }
}