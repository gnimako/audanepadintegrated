using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementLTime: ILkUp_ProcurementLTimeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementLTime> logger;    

        public ServiceLkUp_ProcurementLTime(AppDbContext context, ILogger<ServiceLkUp_ProcurementLTime> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementLTime Add(LkUp_ProcurementLTime rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementLTime.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementLTime Delete(int id)
        {
            LkUp_ProcurementLTime rec = context.LkUp_ProcurementLTime.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementLTime.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementLTime> GetAllRecords()
        {
            return context.LkUp_ProcurementLTime;
        }

        public LkUp_ProcurementLTime GetRecord(int Id)
        {
            return context.LkUp_ProcurementLTime.Find(Id);
        }

        public LkUp_ProcurementLTime GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementLTime
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementLTime Update(LkUp_ProcurementLTime recChanges)
        {
            var rec = context.LkUp_ProcurementLTime.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}