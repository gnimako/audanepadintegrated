using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_Project: ILkUp_ProjectRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_Project> logger;    

        public ServiceLkUp_Project(AppDbContext context, ILogger<ServiceLkUp_Project> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_Project Add(LkUp_Project rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_Project.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_Project Delete(int id)
        {
            LkUp_Project rec = context.LkUp_Project.Find(id);
            if (rec != null)
            {
                context.LkUp_Project.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_Project> GetAllRecords()
        {
            return context.LkUp_Project;
        }

        public IEnumerable<LkUp_Project> GetAllRecordsByDirectorateID(int Id)
        {
            var records = context.LkUp_Project
                    .Where(s => s.Directorate_Id == Id)
                    .ToList();

            return records;
        }



        public IEnumerable<LkUp_Project> GetAllRecordsByDivisionID(int Id)
        {
            var records = context.LkUp_Project
                    .Where(s => s.Division_Id == Id)
                    .ToList();

            return records;
        }

        public IEnumerable<LkUp_Project> GetAllRecordsByProgrammeID(int Id)
        {
                var records = context.LkUp_Project
                    .Where(s => s.Programme_Id == Id)
                    .ToList();

            return records;
        }

        public LkUp_Project GetRecord(int Id)
        {
            return context.LkUp_Project.Find(Id);
        }

        public LkUp_Project GetRecordByName(string name)
        {
            var rec = context.LkUp_Project
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_Project Update(LkUp_Project recChanges)
        {
            var rec = context.LkUp_Project.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}