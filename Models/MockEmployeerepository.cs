using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeerepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeerepository()
        {
            _employeeList = new List<Employee>()
            {
             new Employee() {Id =1, Name ="Jennifer", Department=Dept.SD, Email="Jennifer@g.com"},
             new Employee() { Id = 2, Name = "Mary", Department = Dept.HR, Email = "Mary@g.com" },
             new Employee() { Id = 3, Name = "Kereu", Department = Dept.IT, Email = "Kereu@g.com" },

            };
        }

        public Employee Add(Employee employee)
        {
           employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault( e => e.Id== id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
           return _employeeList;
        }

        public Employee GetEmployee (int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);

            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
                    }
            return employee;
        }
    }
}
