using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProcurementPaymentType: ILkUp_ProcurementPaymentTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProcurementPaymentType> logger;    

        public ServiceLkUp_ProcurementPaymentType(AppDbContext context, ILogger<ServiceLkUp_ProcurementPaymentType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProcurementPaymentType Add(LkUp_ProcurementPaymentType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProcurementPaymentType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProcurementPaymentType Delete(int id)
        {
            LkUp_ProcurementPaymentType rec = context.LkUp_ProcurementPaymentType.Find(id);
            if (rec != null)
            {
                context.LkUp_ProcurementPaymentType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProcurementPaymentType> GetAllRecords()
        {
            return context.LkUp_ProcurementPaymentType;
        }

        public LkUp_ProcurementPaymentType GetRecord(int Id)
        {
            return context.LkUp_ProcurementPaymentType.Find(Id);
        }

        public LkUp_ProcurementPaymentType GetRecordByName(string name)
        {
            var rec = context.LkUp_ProcurementPaymentType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProcurementPaymentType Update(LkUp_ProcurementPaymentType recChanges)
        {
            var rec = context.LkUp_ProcurementPaymentType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}