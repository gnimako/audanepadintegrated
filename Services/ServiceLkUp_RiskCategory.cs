using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_RiskCategory: ILkUp_RiskCategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_RiskCategory> logger;    

        public ServiceLkUp_RiskCategory(AppDbContext context, ILogger<ServiceLkUp_RiskCategory> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_RiskCategory Add(LkUp_RiskCategory rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_RiskCategory.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_RiskCategory Delete(int id)
        {
            LkUp_RiskCategory rec = context.LkUp_RiskCategory.Find(id);
            if (rec != null)
            {
                context.LkUp_RiskCategory.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_RiskCategory> GetAllRecords()
        {
            return context.LkUp_RiskCategory;
        }

        public LkUp_RiskCategory GetRecord(int Id)
        {
            return context.LkUp_RiskCategory.Find(Id);
        }

        public LkUp_RiskCategory GetRecordByName(string name)
        {
            var rec = context.LkUp_RiskCategory
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_RiskCategory Update(LkUp_RiskCategory recChanges)
        {
            var rec = context.LkUp_RiskCategory.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}