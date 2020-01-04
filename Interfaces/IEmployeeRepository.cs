using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        Employee GetEmployeeByEmail(string email);
        Employee GetEmployeeByEmailAndStaffNumber(string email, string staff_number);
        Employee GetEmployeeByLoginIdentAndStaffNumber(string loginident, string staff_number);
        Employee GetEmployeeByStaffNumber(string staffno);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
         
    }
}