using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_KeyPerformanceArea:IStrategy_KeyPerformanceAreaRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStrategy_KeyPerformanceArea> logger;    

        public ServiceStrategy_KeyPerformanceArea(AppDbContext context, ILogger<ServiceStrategy_KeyPerformanceArea> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Strategy_KeyPerformanceArea Add(Strategy_KeyPerformanceArea rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Strategy_KeyPerformanceArea.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Strategy_KeyPerformanceArea Delete(int id)
        {
            Strategy_KeyPerformanceArea rec = context.Strategy_KeyPerformanceArea.Find(id);
            if (rec != null)
            {
                context.Strategy_KeyPerformanceArea.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Strategy_KeyPerformanceArea> GetAllRecords()
        {
            return context.Strategy_KeyPerformanceArea;
        }

        public IEnumerable<Strategy_KeyPerformanceArea> GetAllRecordsByStrategicPriority(int StrategicPriority_Id)
        {
            var records = context.Strategy_KeyPerformanceArea
                                .Where(s => s.StrategicPriority_Id == StrategicPriority_Id)
                                .ToList();

            return records;
        }

        public Strategy_KeyPerformanceArea GetRecord(int Id)
        {
            return context.Strategy_KeyPerformanceArea.Find(Id);
        }



        public Strategy_KeyPerformanceArea GetRecordByName(string name)
        {
            var rec = context.Strategy_KeyPerformanceArea
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        

        public Strategy_KeyPerformanceArea Update(Strategy_KeyPerformanceArea recChanges)
        {
            var rec = context.Strategy_KeyPerformanceArea.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}