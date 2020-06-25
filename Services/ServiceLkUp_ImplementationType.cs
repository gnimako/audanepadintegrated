using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ImplementationType: ILkUp_ImplementationTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ImplementationType> logger;    

        public ServiceLkUp_ImplementationType(AppDbContext context, ILogger<ServiceLkUp_ImplementationType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ImplementationType Add(LkUp_ImplementationType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ImplementationType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ImplementationType Delete(int id)
        {
            LkUp_ImplementationType rec = context.LkUp_ImplementationType.Find(id);
            if (rec != null)
            {
                context.LkUp_ImplementationType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ImplementationType> GetAllRecords()
        {
            return context.LkUp_ImplementationType;
        }

        public LkUp_ImplementationType GetRecord(int Id)
        {
            return context.LkUp_ImplementationType.Find(Id);
        }

        public LkUp_ImplementationType GetRecordByName(string name)
        {
            var rec = context.LkUp_ImplementationType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ImplementationType Update(LkUp_ImplementationType recChanges)
        {
            var rec = context.LkUp_ImplementationType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }

        
    }
}