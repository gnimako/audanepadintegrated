using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementApprovalAuthorityRepository
    {
        Trans_ProcurementApprovalAuthority GetRecord (string Id);

        IEnumerable<Trans_ProcurementApprovalAuthority> GetAllRecords();
        Trans_ProcurementApprovalAuthority Add(Trans_ProcurementApprovalAuthority rec);
        Trans_ProcurementApprovalAuthority Update(Trans_ProcurementApprovalAuthority recChanges);
        Trans_ProcurementApprovalAuthority Delete(string id);
         
         
    }
}