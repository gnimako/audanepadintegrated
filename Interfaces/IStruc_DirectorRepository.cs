using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DirectorRepository
    {
        Struc_Director GetRecord (string Id);

		IEnumerable<Struc_Director> GetAllRecords();

        IEnumerable<Struc_Director> GetAllRecordsByDirectorate (int Directorate_Id);
        Struc_Director GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id);
		Struc_Director Add(Struc_Director rec);
		Struc_Director Update(Struc_Director recChanges);
		Struc_Director Delete(string id);
         
    }
}