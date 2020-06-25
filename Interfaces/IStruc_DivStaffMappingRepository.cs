using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStruc_DivStaffMappingRepository
    {
        Struc_DivStaffMapping GetRecord (string Id);

		IEnumerable<Struc_DivStaffMapping> GetAllRecords();

        IEnumerable<Struc_DivStaffMapping> GetAllRecordsByDivision(int Division_Id);
        IEnumerable<Struc_DivStaffMapping> GetAllRecordsByEmployeeAndDirectorate(int Employee_Id, int Directorate_Id);
        Struc_DivStaffMapping GetRecordByEmployeeAndDirectorsDiv (int Employee_Id, int Directorate_Id);
        Struc_DivStaffMapping GetRecordByEmployeeAndThisPrimaryDivision (int Employee_Id, int Division_Id);
        Struc_DivStaffMapping GetRecordByEmployeeAndPrimaryDivision (int Employee_Id);

        Struc_DivStaffMapping GetRecordByEmployee (int Employee_Id);
        Struc_DivStaffMapping GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id);
		Struc_DivStaffMapping Add(Struc_DivStaffMapping rec);
		Struc_DivStaffMapping Update(Struc_DivStaffMapping recChanges);
		Struc_DivStaffMapping Delete(string id);
         
    }
}