using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_RiskProbability: ILkUp_RiskProbabilityRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_RiskProbability> logger;    

        public ServiceLkUp_RiskProbability(AppDbContext context, ILogger<ServiceLkUp_RiskProbability> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_RiskProbability Add(LkUp_RiskProbability rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_RiskProbability.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_RiskProbability Delete(int id)
        {
            LkUp_RiskProbability rec = context.LkUp_RiskProbability.Find(id);
            if (rec != null)
            {
                context.LkUp_RiskProbability.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_RiskProbability> GetAllRecords()
        {
            return context.LkUp_RiskProbability;
        }

        public LkUp_RiskProbability GetRecord(int Id)
        {
            return context.LkUp_RiskProbability.Find(Id);
        }

        public LkUp_RiskProbability GetRecordByName(string name)
        {
            var rec = context.LkUp_RiskProbability
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_RiskProbability Update(LkUp_RiskProbability recChanges)
        {
            var rec = context.LkUp_RiskProbability.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}