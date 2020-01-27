using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_CostCatelogue : ILkUp_CostCatelogueRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ILkUp_CostCatelogueRepository> logger;

        public ServiceLkUp_CostCatelogue(AppDbContext context, ILogger<ILkUp_CostCatelogueRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public LkUp_CostCatelogue Add(LkUp_CostCatelogue rec)
        {
            rec.Cost_Id = GetAllCostCatelogue().Count() + 1;
            context.LkUp_CostCatelogue.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_CostCatelogue Delete(int id)
        {
            LkUp_CostCatelogue rec = context.LkUp_CostCatelogue.Find(id);
            if (rec != null)
            {
                context.LkUp_CostCatelogue.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_CostCatelogue> GetAllCostCatelogue()
        {
            return context.LkUp_CostCatelogue;
        }

        public LkUp_CostCatelogue GetCostCatelogue(int Id)
        {
            return context.LkUp_CostCatelogue.Find(Id);
        }

        public IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByCostCategory(string category)
        {
            var records = context.LkUp_CostCatelogue
                                .Where(s => s.Cost_Category == category)
                                .ToList();

            return records;
        }

        public IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByCostCode(string code)
        {
            var records = context.LkUp_CostCatelogue
                                .Where(s => s.Cost_Code == code)
                                .ToList();

            return records;
        }

        public IEnumerable<LkUp_CostCatelogue> GetCostCatelogueByDescriptionExpression(string expression)
        {
            var records = context.LkUp_CostCatelogue
                            .Where(s=>s.Cost_Description.Contains(expression))
                            .ToList();
            return records;
        }

        public LkUp_CostCatelogue Update(LkUp_CostCatelogue recChanges)
        {
            var rec = context.LkUp_CostCatelogue.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}