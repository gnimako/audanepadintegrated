using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ProjectScope : ILkUp_ProjectScopeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ProjectScope> logger;    

        public ServiceLkUp_ProjectScope(AppDbContext context, ILogger<ServiceLkUp_ProjectScope> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ProjectScope Add(LkUp_ProjectScope rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ProjectScope.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ProjectScope Delete(int id)
        {
            LkUp_ProjectScope rec = context.LkUp_ProjectScope.Find(id);
            if (rec != null)
            {
                context.LkUp_ProjectScope.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ProjectScope> GetAllRecords()
        {
            return context.LkUp_ProjectScope;
        }

        public LkUp_ProjectScope GetRecord(int Id)
        {
            return context.LkUp_ProjectScope.Find(Id);
        }

        public LkUp_ProjectScope GetRecordByName(string name)
        {
            var rec = context.LkUp_ProjectScope
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ProjectScope Update(LkUp_ProjectScope recChanges)
        {
            var rec = context.LkUp_ProjectScope.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}