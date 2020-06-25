using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DirectorOICRepository
    {
        Struc_DirectorOIC GetRecord (string Id);

		IEnumerable<Struc_DirectorOIC> GetAllRecords();

        IEnumerable<Struc_DirectorOIC> GetAllRecordsByDirectorate (int Directorate_Id);
        Struc_DirectorOIC GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id);
		Struc_DirectorOIC Add(Struc_DirectorOIC rec);
		Struc_DirectorOIC Update(Struc_DirectorOIC recChanges);
		Struc_DirectorOIC Delete(string id);
         
    }
}