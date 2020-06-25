using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;



namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DirStaffMappingRepository
    {
        Struc_DirStaffMapping GetRecord (string Id);

		IEnumerable<Struc_DirStaffMapping> GetAllRecords();
        IEnumerable<Struc_DirStaffMapping> GetAllRecordsByDirectorate(int Directorate_Id);
        Struc_DirStaffMapping GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id);
        Struc_DirStaffMapping GetRecordByEmployeeAndPrimaryDirectorate (int Employee_Id);
        Struc_DirStaffMapping GetRecordByEmployeeAndThisPrimaryDirectorate (int Employee_Id, int Directorate_Id);
		Struc_DirStaffMapping Add(Struc_DirStaffMapping rec);
		Struc_DirStaffMapping Update(Struc_DirStaffMapping recChanges);
		Struc_DirStaffMapping Delete(string id);
         
    }
}