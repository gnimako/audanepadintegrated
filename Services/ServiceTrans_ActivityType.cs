using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ActivityType : ITrans_ActivityTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_ActivityType> logger;

        public ServiceTrans_ActivityType(AppDbContext context, ILogger<ServiceTrans_ActivityType> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Trans_ActivityType Add(Trans_ActivityType rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_ActivityType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_ActivityType Delete(string id)
        {
            Trans_ActivityType rec = context.Trans_ActivityType.Find(id);
            if (rec != null)
            {
                context.Trans_ActivityType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_ActivityType> GetAllTransActivityType()
        {
            return context.Trans_ActivityType;
        }

        public Trans_ActivityType GetTrans_ActivityType(string Id)
        {
            return context.Trans_ActivityType.Find(Id);
        }

        public Trans_ActivityType Update(Trans_ActivityType recChanges)
        {
            var rec = context.Trans_ActivityType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}