using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_Directorate: IStruc_DirectorateRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStruc_Directorate> logger;    

        public ServiceStruc_Directorate(AppDbContext context, ILogger<ServiceStruc_Directorate> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Struc_Directorate Add(Struc_Directorate rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Struc_Directorate.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Struc_Directorate Delete(int id)
        {
            Struc_Directorate rec = context.Struc_Directorate.Find(id);
            if (rec != null)
            {
                context.Struc_Directorate.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Struc_Directorate> GetAllRecords()
        {
            return context.Struc_Directorate;
        }

        public Struc_Directorate GetRecord(int Id)
        {
            return context.Struc_Directorate.Find(Id);
        }

        public Struc_Directorate GetRecordByName(string name)
        {
            var rec = context.Struc_Directorate
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public Struc_Directorate Update(Struc_Directorate recChanges)
        {
            var rec = context.Struc_Directorate.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}