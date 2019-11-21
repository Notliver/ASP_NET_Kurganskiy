using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Kurganskiy.ViewModels;

namespace ASP_NET_Kurganskiy.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {/// <summary>
    /// Method to take all Employees
    /// </summary>
    /// <returns>All Employees</returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>
        /// Method to get Employee by ID
        /// </summary>
        /// <param name="Id">ID of Employees</param>
        /// <returns>Employee with matched ID</returns>
        EmployeeView GetById(int Id);

        /// <summary>
        /// Method to Add ne Employee
        /// </summary>
        /// <param name="Employee">Create and add new Employee</param>
        void Add(EmployeeView Employee);

        /// <summary>
        /// Edit current Employee by ID
        /// </summary>
        /// <param name="Id">Employee Id</param>
        /// <param name="Employee">Model of Employee</param>
        void Edit(int Id, EmployeeView Employee);

        /// <summary>
        /// Method to Delete Employee by Id
        /// </summary>
        /// <param name="Id">Id of Employee</param>
        bool Delete(int Id);

        /// <summary>
        /// Approve Changes
        /// </summary>
        void SaveChanges();
    }
}
