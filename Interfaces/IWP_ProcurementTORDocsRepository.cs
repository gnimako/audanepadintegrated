using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementTORDocsRepository
    {
        WP_ProcurementTORDocs GetRecord (string Id);
        IEnumerable<WP_ProcurementTORDocs> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_ProcurementTORDocs> GetRecordsByProcurementId (string recid);

        IEnumerable<WP_ProcurementTORDocs> GetAllRecords();

        WP_ProcurementTORDocs GetRecordByProcurementIdAndFilename (string recid, string filename);

    
        WP_ProcurementTORDocs Add(WP_ProcurementTORDocs rec);
        WP_ProcurementTORDocs Update(WP_ProcurementTORDocs recChanges);
        WP_ProcurementTORDocs Delete(string id);
         
    }
}