using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementProcessRepository
    {
        WP_ProcurementProcess GetRecord (string Id);
        IEnumerable<WP_ProcurementProcess> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_ProcurementProcess> GetRecordsByProcurementId (string recid);

        IEnumerable<WP_ProcurementProcess> GetAllRecords();

        WP_ProcurementProcess GetRecordByProcurementId (string recid);

    
        WP_ProcurementProcess Add(WP_ProcurementProcess rec);
        WP_ProcurementProcess Update(WP_ProcurementProcess recChanges);
        WP_ProcurementProcess Delete(string id);
         
         
    }
}