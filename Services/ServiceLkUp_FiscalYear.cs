using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_FiscalYear: ILkUp_FiscalYearRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_FiscalYear> logger;    

        public ServiceLkUp_FiscalYear(AppDbContext context, ILogger<ServiceLkUp_FiscalYear> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_FiscalYear Add(LkUp_FiscalYear rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_FiscalYear.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_FiscalYear Delete(int id)
        {
            LkUp_FiscalYear rec = context.LkUp_FiscalYear.Find(id);
            if (rec != null)
            {
                context.LkUp_FiscalYear.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_FiscalYear> GetAllRecords()
        {
            return context.LkUp_FiscalYear;
        }

        public LkUp_FiscalYear GetRecord(int Id)
        {
            return context.LkUp_FiscalYear.Find(Id);
        }

        public LkUp_FiscalYear GetRecordByName(string name)
        {
            var rec = context.LkUp_FiscalYear
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_FiscalYear Update(LkUp_FiscalYear recChanges)
        {
            var rec = context.LkUp_FiscalYear.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}