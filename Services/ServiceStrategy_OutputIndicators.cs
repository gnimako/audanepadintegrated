using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;




namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_OutputIndicators: IStrategy_OutputIndicatorsRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStrategy_OutputIndicators> logger;    

        public ServiceStrategy_OutputIndicators(AppDbContext context, ILogger<ServiceStrategy_OutputIndicators> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Strategy_OutputIndicators Add(Strategy_OutputIndicators rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Strategy_OutputIndicators.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Strategy_OutputIndicators Delete(int id)
        {
            Strategy_OutputIndicators rec = context.Strategy_OutputIndicators.Find(id);
            if (rec != null)
            {
                context.Strategy_OutputIndicators.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Strategy_OutputIndicators> GetAllRecords()
        {
            return context.Strategy_OutputIndicators;
        }

        public Strategy_OutputIndicators GetRecord(int Id)
        {
            return context.Strategy_OutputIndicators.Find(Id);
        }

        public Strategy_OutputIndicators GetRecordByName(string name)
        {
            var rec = context.Strategy_OutputIndicators
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public Strategy_OutputIndicators Update(Strategy_OutputIndicators recChanges)
        {
            var rec = context.Strategy_OutputIndicators.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}