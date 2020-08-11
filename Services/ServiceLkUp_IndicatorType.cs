using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_IndicatorType: ILkUp_IndicatorTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_IndicatorType> logger;    

        public ServiceLkUp_IndicatorType(AppDbContext context, ILogger<ServiceLkUp_IndicatorType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_IndicatorType Add(LkUp_IndicatorType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_IndicatorType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_IndicatorType Delete(int id)
        {
            LkUp_IndicatorType rec = context.LkUp_IndicatorType.Find(id);
            if (rec != null)
            {
                context.LkUp_IndicatorType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_IndicatorType> GetAllRecords()
        {
            return context.LkUp_IndicatorType;
        }

        public LkUp_IndicatorType GetRecord(int Id)
        {
            return context.LkUp_IndicatorType.Find(Id);
        }

        public LkUp_IndicatorType GetRecordByName(string name)
        {
            var rec = context.LkUp_IndicatorType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_IndicatorType Update(LkUp_IndicatorType recChanges)
        {
            var rec = context.LkUp_IndicatorType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}