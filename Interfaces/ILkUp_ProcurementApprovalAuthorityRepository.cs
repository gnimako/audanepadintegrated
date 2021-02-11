using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementApprovalAuthorityRepository
    {
        LkUp_ProcurementApprovalAuthority GetRecord(int Id);

        LkUp_ProcurementApprovalAuthority GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementApprovalAuthority> GetAllRecords();
        LkUp_ProcurementApprovalAuthority Add(LkUp_ProcurementApprovalAuthority rec);
        LkUp_ProcurementApprovalAuthority Update(LkUp_ProcurementApprovalAuthority recChanges);
        LkUp_ProcurementApprovalAuthority Delete(int id);
         
    }
}