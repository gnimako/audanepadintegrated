using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_RiskRTimeframe: ILkUp_RiskRTimeframeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_RiskRTimeframe> logger;    

        public ServiceLkUp_RiskRTimeframe(AppDbContext context, ILogger<ServiceLkUp_RiskRTimeframe> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_RiskRTimeframe Add(LkUp_RiskRTimeframe rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_RiskRTimeframe.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_RiskRTimeframe Delete(int id)
        {
            LkUp_RiskRTimeframe rec = context.LkUp_RiskRTimeframe.Find(id);
            if (rec != null)
            {
                context.LkUp_RiskRTimeframe.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_RiskRTimeframe> GetAllRecords()
        {
            return context.LkUp_RiskRTimeframe;
        }

        public LkUp_RiskRTimeframe GetRecord(int Id)
        {
            return context.LkUp_RiskRTimeframe.Find(Id);
        }

        public LkUp_RiskRTimeframe GetRecordByName(string name)
        {
            var rec = context.LkUp_RiskRTimeframe
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_RiskRTimeframe Update(LkUp_RiskRTimeframe recChanges)
        {
            var rec = context.LkUp_RiskRTimeframe.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}