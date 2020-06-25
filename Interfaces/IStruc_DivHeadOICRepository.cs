using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DivHeadOICRepository
    {
        Struc_DivHeadOIC GetRecord (string Id);

		IEnumerable<Struc_DivHeadOIC> GetAllRecords();

        IEnumerable<Struc_DivHeadOIC> GetAllRecordsByDivision(int Division_Id);
        Struc_DivHeadOIC GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id);
		Struc_DivHeadOIC Add(Struc_DivHeadOIC rec);
		Struc_DivHeadOIC Update(Struc_DivHeadOIC recChanges);
		Struc_DivHeadOIC Delete(string id);
        
         
    }
}