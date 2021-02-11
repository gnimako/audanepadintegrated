using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementProcessSteps: ILkUp_ProcurementProcessStepsRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementProcessSteps> logger;    

        public ServiceLkUp_ProcurementProcessSteps(AppDbContext context, ILogger<ServiceLkUp_ProcurementProcessSteps> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementProcessSteps Add(LkUp_ProcurementProcessSteps rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementProcessSteps.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementProcessSteps Delete(int id)
        {
            LkUp_ProcurementProcessSteps rec = context.LkUp_ProcurementProcessSteps.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementProcessSteps.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementProcessSteps> GetAllRecords()
        {
            return context.LkUp_ProcurementProcessSteps;
        }

        public LkUp_ProcurementProcessSteps GetRecord(int Id)
        {
            return context.LkUp_ProcurementProcessSteps.Find(Id);
        }

        public LkUp_ProcurementProcessSteps GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementProcessSteps
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementProcessSteps Update(LkUp_ProcurementProcessSteps recChanges)
        {
            var rec = context.LkUp_ProcurementProcessSteps.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}