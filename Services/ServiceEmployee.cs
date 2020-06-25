using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceEmployee : IEmployeeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceEmployee> logger;

        

        public ServiceEmployee(AppDbContext context, ILogger<ServiceEmployee> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = GetAllEmployee().Count() + 1;//_employeeList.Max(e => e.Id) + 1;
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            //logger.LogTrace("Trace Log");
            //logger.LogDebug("Debug Log");
            //logger.LogInformation("Information Log");
            //logger.LogWarning("Warning Log");
            //logger.LogError("Error Log");
            //logger.LogCritical("Critical Log");

            return context.Employees.Find(Id);
        }

        public Employee GetEmployeeByEmail(string email)
        {

            var employee = context.Employees
                                     .Where(s => s.Email == email)
                                     .FirstOrDefault();
            return employee;
        }

        public Employee GetEmployeeByEmailAndStaffNumber(string email, string staff_number)
        {
            var employee = context.Employees
                         .Where(s => s.Email == email && s.Staff_Number==staff_number)
                         .FirstOrDefault();
            return employee;
        }

        public Employee GetEmployeeByLoginIdentAndStaffNumber(string loginident, string staff_number)
        {
            var employee = context.Employees
             .Where(s => s.IdentityUserId == loginident && s.Staff_Number == staff_number)
             .FirstOrDefault();
            return employee;
        }

        public Employee GetEmployeeByStaffNumber(string staffno)
        {
            var employee = context.Employees
                         .Where(s => s.Staff_Number == staffno)
                         .FirstOrDefault();
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
        
    }
}