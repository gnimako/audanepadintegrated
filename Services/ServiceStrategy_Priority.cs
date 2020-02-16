using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_Priority: IStrategy_PriorityRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStrategy_Priority> logger;    

        public ServiceStrategy_Priority(AppDbContext context, ILogger<ServiceStrategy_Priority> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Strategy_Priority Add(Strategy_Priority rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Strategy_Priority.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Strategy_Priority Delete(int id)
        {
            Strategy_Priority rec = context.Strategy_Priority.Find(id);
            if (rec != null)
            {
                context.Strategy_Priority.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Strategy_Priority> GetAllRecords()
        {
            return context.Strategy_Priority;
        }

        public Strategy_Priority GetRecord(int Id)
        {
            return context.Strategy_Priority.Find(Id);
        }

        public Strategy_Priority GetRecordByName(string name)
        {
            var rec = context.Strategy_Priority
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public Strategy_Priority Update(Strategy_Priority recChanges)
        {
            var rec = context.Strategy_Priority.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}