using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_MobilityLimits: ILkUp_MobilityLimitsRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_MobilityLimits> logger;    

        public ServiceLkUp_MobilityLimits(AppDbContext context, ILogger<ServiceLkUp_MobilityLimits> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_MobilityLimits Add(LkUp_MobilityLimits rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_MobilityLimits.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_MobilityLimits Delete(int id)
        {
            LkUp_MobilityLimits rec = context.LkUp_MobilityLimits.Find(id);
            if (rec != null)
            {
                context.LkUp_MobilityLimits.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_MobilityLimits> GetAllRecords()
        {
            return context.LkUp_MobilityLimits;
        }

        public LkUp_MobilityLimits GetRecord(int Id)
        {
            return context.LkUp_MobilityLimits.Find(Id);
        }



        public LkUp_MobilityLimits Update(LkUp_MobilityLimits recChanges)
        {
            var rec = context.LkUp_MobilityLimits.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}