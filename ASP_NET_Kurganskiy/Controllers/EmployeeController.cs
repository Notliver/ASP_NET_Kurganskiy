using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Kurganskiy.ViewModels;
using ASP_NET_Kurganskiy.Infrastructure.Services;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;

namespace ASP_NET_Kurganskiy.Controllers
{
    //[Route("Users")]
    public class EmployeeController : Controller
        
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeeController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;
        
        public IActionResult Index()
        {
            return View(_EmployeesData);
        }

        //[Route("Id")]
        public IActionResult Details(int? Id)
        {
            if (Id is null) return BadRequest();
            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        public IActionResult DetailsName(string FirstName, string SurName)
        {
            if (FirstName is null && SurName is null)
                return BadRequest();
            IEnumerable<EmployeeView> employees = _EmployeesData.GetAll();
            if (!string.IsNullOrWhiteSpace(FirstName))
                employees = employees.Where(e => e.FirstName == FirstName);
            if (!string.IsNullOrWhiteSpace(SurName))
                employees = employees.Where(e => e.SurName == SurName);

            var employee = employees.FirstOrDefault();
            if (employee is null)
                return NotFound();
            return View(nameof(Details), employee);

        }

        //public IActionResult Edit(EmployeeView EmployeInfo)
        //{
        //    if (!ModelState.IsValid) return View(EmployeInfo);
        //    var employee = _Employees.FirstOrDefault(e => e.Id == EmployeInfo.Id);
        //    if (employee is null) return NotFound();
        //    employee.FirstName = EmployeInfo.FirstName;
        //    employee.SurName = EmployeInfo.SurName;
        //    employee.Patronymic = EmployeInfo.Patronymic;
        //    employee.Age = EmployeInfo.Age;
        //    return RedirectToAction(nameof(Details), new { id = EmployeInfo.Id });
        //}
    }
}