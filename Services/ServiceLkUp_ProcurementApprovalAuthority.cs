using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementApprovalAuthority:ILkUp_ProcurementApprovalAuthorityRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementApprovalAuthority> logger;    

        public ServiceLkUp_ProcurementApprovalAuthority(AppDbContext context, ILogger<ServiceLkUp_ProcurementApprovalAuthority> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementApprovalAuthority Add(LkUp_ProcurementApprovalAuthority rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementApprovalAuthority.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementApprovalAuthority Delete(int id)
        {
            LkUp_ProcurementApprovalAuthority rec = context.LkUp_ProcurementApprovalAuthority.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementApprovalAuthority.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementApprovalAuthority> GetAllRecords()
        {
            return context.LkUp_ProcurementApprovalAuthority;
        }

        public LkUp_ProcurementApprovalAuthority GetRecord(int Id)
        {
            return context.LkUp_ProcurementApprovalAuthority.Find(Id);
        }

        public LkUp_ProcurementApprovalAuthority GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementApprovalAuthority
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementApprovalAuthority Update(LkUp_ProcurementApprovalAuthority recChanges)
        {
            var rec = context.LkUp_ProcurementApprovalAuthority.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}