using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_Period: ILkUp_PeriodRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_Period> logger;    

        public ServiceLkUp_Period(AppDbContext context, ILogger<ServiceLkUp_Period> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_Period Add(LkUp_Period rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_Period.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_Period Delete(int id)
        {
            LkUp_Period rec = context.LkUp_Period.Find(id);
            if (rec != null)
            {
                context.LkUp_Period.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_Period> GetAllRecords()
        {
            return context.LkUp_Period;
        }

        public LkUp_Period GetRecord(int Id)
        {
            return context.LkUp_Period.Find(Id);
        }

        public LkUp_Period GetRecordByName(string name)
        {
            var rec = context.LkUp_Period
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_Period Update(LkUp_Period recChanges)
        {
            var rec = context.LkUp_Period.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}