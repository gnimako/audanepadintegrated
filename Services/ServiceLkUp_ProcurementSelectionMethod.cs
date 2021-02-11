using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementSelectionMethod: ILkUp_ProcurementSelectionMethodRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementSelectionMethod> logger;    

        public ServiceLkUp_ProcurementSelectionMethod(AppDbContext context, ILogger<ServiceLkUp_ProcurementSelectionMethod> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementSelectionMethod Add(LkUp_ProcurementSelectionMethod rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementSelectionMethod.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementSelectionMethod Delete(int id)
        {
            LkUp_ProcurementSelectionMethod rec = context.LkUp_ProcurementSelectionMethod.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementSelectionMethod.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementSelectionMethod> GetAllRecords()
        {
            return context.LkUp_ProcurementSelectionMethod;
        }

        public LkUp_ProcurementSelectionMethod GetRecord(int Id)
        {
            return context.LkUp_ProcurementSelectionMethod.Find(Id);
        }

        public LkUp_ProcurementSelectionMethod GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementSelectionMethod
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementSelectionMethod Update(LkUp_ProcurementSelectionMethod recChanges)
        {
            var rec = context.LkUp_ProcurementSelectionMethod.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}