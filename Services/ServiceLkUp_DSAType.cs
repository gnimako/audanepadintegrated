using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_DSAType : ILkUp_DSATypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_DSAType> logger;

        public ServiceLkUp_DSAType(AppDbContext context, ILogger<ServiceLkUp_DSAType> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public LkUp_DSAType Add(LkUp_DSAType rec)
        {
            rec.DSA_Id = GetAllDSAType().Count() + 1;
            context.LkUp_DSAType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_DSAType Delete(int id)
        {
            LkUp_DSAType rec = context.LkUp_DSAType.Find(id);
            if (rec != null)
            {
                context.LkUp_DSAType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_DSAType> GetAllDSAType()
        {
            return context.LkUp_DSAType;
        }

        public LkUp_DSAType GetDSAType(int Id)
        {
            return context.LkUp_DSAType.Find(Id);
        }

        public LkUp_DSAType GetDSATypeByName(string name)
        {
            var rec = context.LkUp_DSAType
                            .Where(s => s.DSA_Name == name)
                            .FirstOrDefault();
            return rec;
        }

        public LkUp_DSAType Update(LkUp_DSAType recChanges)
        {
            var rec = context.LkUp_DSAType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}