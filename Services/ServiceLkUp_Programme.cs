using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_Programme:ILkUp_ProgrammeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_Programme> logger;    

        public ServiceLkUp_Programme(AppDbContext context, ILogger<ServiceLkUp_Programme> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_Programme Add(LkUp_Programme rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_Programme.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_Programme Delete(int id)
        {
            LkUp_Programme rec = context.LkUp_Programme.Find(id);
            if (rec != null)
            {
                context.LkUp_Programme.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_Programme> GetAllRecords()
        {
            return context.LkUp_Programme;
        }

        public IEnumerable<LkUp_Programme> GetAllRecordsByDirectorateID(int Id)
        {
            var records = context.LkUp_Programme
                    .Where(s => s.Directorate_Id == Id)
                    .ToList();

            return records;
        }



        public IEnumerable<LkUp_Programme> GetAllRecordsByDivisionID(int Id)
        {
            var records = context.LkUp_Programme
                    .Where(s => s.Division_Id == Id)
                    .ToList();

            return records;
        }



        public LkUp_Programme GetRecord(int Id)
        {
            return context.LkUp_Programme.Find(Id);
        }

        public LkUp_Programme GetRecordByName(string name)
        {
            var rec = context.LkUp_Programme
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_Programme Update(LkUp_Programme recChanges)
        {
            var rec = context.LkUp_Programme.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}