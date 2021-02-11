using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementWorkLoadAssignmentRepository
    {
        WP_ProcurementWorkLoadAssignment GetRecord (string Id);
        IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByProcurementId (string recid);
        IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByEmployeeIdAndStatus (int empid, string status);

        IEnumerable<WP_ProcurementWorkLoadAssignment> GetAllRecords();

        WP_ProcurementWorkLoadAssignment GetRecordByProcurementIdAndEmployeeId (string procid, int empid);

    
        WP_ProcurementWorkLoadAssignment Add(WP_ProcurementWorkLoadAssignment rec);
        WP_ProcurementWorkLoadAssignment Update(WP_ProcurementWorkLoadAssignment recChanges);
        WP_ProcurementWorkLoadAssignment Delete(string id);
         
    }
}