using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using ASP_NET_Kurganskiy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.Infrastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeView> _Employees = new List<EmployeeView>
        {
            new EmployeeView{Id = 1, FirstName = "Иван", SurName = "Иванов", Patronymic = "Иванович", Age = 19},
            new EmployeeView{Id = 2, FirstName = "Петр", SurName = "Петров", Patronymic = "Петрович", Age = 21},
            new EmployeeView{Id = 3, FirstName = "Олег", SurName = "Олегов", Patronymic = "Олегович", Age = 19}
        };

        public void Add(EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentException(nameof(Employee));

            Employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(Employee); 
        }

        public bool Delete(int Id)
        {
            var db_employee = GetById(Id);
            if (db_employee is null) return false;
            return _Employees.Remove(db_employee);
        }

        public void Edit(int Id, EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentException(nameof(Employee));
            var db_employee = GetById(Id);
            if (db_employee is null) return;

            db_employee.FirstName = Employee.FirstName;
            db_employee.SurName = Employee.SurName;
            db_employee.Patronymic = Employee.Patronymic;
            db_employee.Age = Employee.Age;
        }
        public IEnumerable<EmployeeView> GetAll() => _Employees;

        public EmployeeView GetById(int Id) => _Employees.FirstOrDefault(e => e.Id == Id);

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
