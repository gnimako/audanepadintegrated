using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_RiskImpact: ILkUp_RiskImpactRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_RiskImpact> logger;    

        public ServiceLkUp_RiskImpact(AppDbContext context, ILogger<ServiceLkUp_RiskImpact> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_RiskImpact Add(LkUp_RiskImpact rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_RiskImpact.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_RiskImpact Delete(int id)
        {
            LkUp_RiskImpact rec = context.LkUp_RiskImpact.Find(id);
            if (rec != null)
            {
                context.LkUp_RiskImpact.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_RiskImpact> GetAllRecords()
        {
            return context.LkUp_RiskImpact;
        }

        public LkUp_RiskImpact GetRecord(int Id)
        {
            return context.LkUp_RiskImpact.Find(Id);
        }

        public LkUp_RiskImpact GetRecordByName(string name)
        {
            var rec = context.LkUp_RiskImpact
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_RiskImpact Update(LkUp_RiskImpact recChanges)
        {
            var rec = context.LkUp_RiskImpact.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}