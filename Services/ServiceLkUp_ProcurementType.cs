using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementType: ILkUp_ProcurementTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementType> logger;    

        public ServiceLkUp_ProcurementType(AppDbContext context, ILogger<ServiceLkUp_ProcurementType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementType Add(LkUp_ProcurementType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementType Delete(int id)
        {
            LkUp_ProcurementType rec = context.LkUp_ProcurementType.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementType> GetAllRecords()
        {
            return context.LkUp_ProcurementType;
        }

        public LkUp_ProcurementType GetRecord(int Id)
        {
            return context.LkUp_ProcurementType.Find(Id);
        }

        public LkUp_ProcurementType GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementType Update(LkUp_ProcurementType recChanges)
        {
            var rec = context.LkUp_ProcurementType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}