using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ActivityType : ILkUp_ActivityTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ActivityType> logger;
        public ServiceLkUp_ActivityType(AppDbContext context, ILogger<ServiceLkUp_ActivityType> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public LkUp_ActivityType Add(LkUp_ActivityType atype)
        {
            atype.Activity_Id = GetAllActivityType().Count() + 1;
            context.LkUp_ActivityType.Add(atype);
            context.SaveChanges();
            return atype;
        }

        public LkUp_ActivityType Delete(int id)
        {
            LkUp_ActivityType atype = context.LkUp_ActivityType.Find(id);
            if (atype != null)
            {
                context.LkUp_ActivityType.Remove(atype);
                context.SaveChanges();
            }
            return atype;
        }

        public LkUp_ActivityType GetActivityType(int Id)
        {
            return context.LkUp_ActivityType.Find(Id);
        }

        public LkUp_ActivityType GetActivityTypeByName(string name)
        {
            var atype = context.LkUp_ActivityType
                                  .Where(s => s.Activity_Name == name)
                                  .FirstOrDefault();
            return atype;
        }

        public IEnumerable<LkUp_ActivityType> GetAllActivityType()
        {
            return context.LkUp_ActivityType;
        }

        public LkUp_ActivityType Update(LkUp_ActivityType atypeChanges)
        {
            var satype = context.LkUp_ActivityType.Attach(atypeChanges);
            satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return atypeChanges;
        }

        
    }
}