using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_MTP: IStrategy_MTPRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStrategy_MTP> logger;    

        public ServiceStrategy_MTP(AppDbContext context, ILogger<ServiceStrategy_MTP> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Strategy_MTP Add(Strategy_MTP rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Strategy_MTP.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Strategy_MTP Delete(int id)
        {
            Strategy_MTP rec = context.Strategy_MTP.Find(id);
            if (rec != null)
            {
                context.Strategy_MTP.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Strategy_MTP> GetAllRecords()
        {
            return context.Strategy_MTP;
        }

        public Strategy_MTP GetRecord(int Id)
        {
            return context.Strategy_MTP.Find(Id);
        }

        public Strategy_MTP GetRecordByName(string name)
        {
            var rec = context.Strategy_MTP
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public Strategy_MTP Update(Strategy_MTP recChanges)
        {
            var rec = context.Strategy_MTP.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}