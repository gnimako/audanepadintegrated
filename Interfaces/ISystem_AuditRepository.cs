using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ISystem_AuditRepository
    {
        System_Audit GetSystem_Audit(string Id);

		IEnumerable<System_Audit> GetAllSystem_Audit();
        System_Audit Add(System_Audit rec);
        System_Audit Update(System_Audit recChanges);
        System_Audit Delete(string id);
         
    }
}