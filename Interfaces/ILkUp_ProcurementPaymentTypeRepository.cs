using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementPaymentTypeRepository
    {
        LkUp_ProcurementPaymentType GetRecord(int Id);

        LkUp_ProcurementPaymentType GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementPaymentType> GetAllRecords();
        LkUp_ProcurementPaymentType Add(LkUp_ProcurementPaymentType rec);
        LkUp_ProcurementPaymentType Update(LkUp_ProcurementPaymentType recChanges);
        LkUp_ProcurementPaymentType Delete(int id);
         
    }
}