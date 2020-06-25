using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceSystem_Audit : ISystem_AuditRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceSystem_Audit> logger;

        public ServiceSystem_Audit(AppDbContext context, ILogger<ServiceSystem_Audit> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public System_Audit Add(System_Audit rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.System_Audit.Add(rec);
            context.SaveChanges();
            return rec;
        }

 

        public System_Audit Delete(string id)
        {
            System_Audit rec = context.System_Audit.Find(id);
            if (rec != null)
            {
                context.System_Audit.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<System_Audit> GetAllSystem_Audit()
        {
            return context.System_Audit;
        }

        public System_Audit GetSystem_Audit(string Id)
        {
            return context.System_Audit.Find(Id);
        }

        public System_Audit Update(System_Audit recChanges)
        {
            var rec = context.System_Audit.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }

  





    }
}