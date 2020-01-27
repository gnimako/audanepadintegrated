using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_DSAType : ITrans_DSATypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_DSAType> logger;

        public ServiceTrans_DSAType(AppDbContext context, ILogger<ServiceTrans_DSAType> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Trans_DSAType Add(Trans_DSAType rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_DSAType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_DSAType Delete(string id)
        {
            Trans_DSAType rec = context.Trans_DSAType.Find(id);
            if (rec != null)
            {
                context.Trans_DSAType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_DSAType> GetAllTransDSAType()
        {
            return context.Trans_DSAType;
        }

        public Trans_DSAType GetTrans_DSAType(string Id)
        {
            return context.Trans_DSAType.Find(Id);
        }

        public Trans_DSAType Update(Trans_DSAType recChanges)
        {
            var rec = context.Trans_DSAType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}