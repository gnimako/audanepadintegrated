using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_CostCatelogue : ITrans_CostCatelogueRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_CostCatelogue> logger;

        public ServiceTrans_CostCatelogue(AppDbContext context, ILogger<ServiceTrans_CostCatelogue> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Trans_CostCatelogue Add(Trans_CostCatelogue rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_CostCatelogue.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_CostCatelogue Delete(string id)
        {
            Trans_CostCatelogue rec = context.Trans_CostCatelogue.Find(id);
            if (rec != null)
            {
                context.Trans_CostCatelogue.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_CostCatelogue> GetAllTransCostCatelogue()
        {
            return context.Trans_CostCatelogue;
        }

        public Trans_CostCatelogue GetTrans_CostCatelogue(string Id)
        {
            return context.Trans_CostCatelogue.Find(Id);
        }

        public Trans_CostCatelogue Update(Trans_CostCatelogue recChanges)
        {
            var rec = context.Trans_CostCatelogue.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}