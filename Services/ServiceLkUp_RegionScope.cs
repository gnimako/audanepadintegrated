using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_RegionScope: ILkUp_RegionScopeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_RegionScope> logger;    

        public ServiceLkUp_RegionScope(AppDbContext context, ILogger<ServiceLkUp_RegionScope> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_RegionScope Add(LkUp_RegionScope rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_RegionScope.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_RegionScope Delete(int id)
        {
            LkUp_RegionScope rec = context.LkUp_RegionScope.Find(id);
            if (rec != null)
            {
                context.LkUp_RegionScope.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_RegionScope> GetAllRecords()
        {
            return context.LkUp_RegionScope;
        }

        public LkUp_RegionScope GetRecord(int Id)
        {
            return context.LkUp_RegionScope.Find(Id);
        }

        public LkUp_RegionScope GetRecordByName(string name)
        {
            var rec = context.LkUp_RegionScope
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_RegionScope Update(LkUp_RegionScope recChanges)
        {
            var rec = context.LkUp_RegionScope.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}