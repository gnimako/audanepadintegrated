using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementPaymentTypeRepository
    {
        Trans_ProcurementPaymentType GetRecord (string Id);

        IEnumerable<Trans_ProcurementPaymentType> GetAllRecords();
        Trans_ProcurementPaymentType Add(Trans_ProcurementPaymentType rec);
        Trans_ProcurementPaymentType Update(Trans_ProcurementPaymentType recChanges);
        Trans_ProcurementPaymentType Delete(string id);
         
    }
}