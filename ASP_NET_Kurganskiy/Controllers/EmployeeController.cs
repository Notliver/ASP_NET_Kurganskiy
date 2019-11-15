using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Kurganskiy.ViewModels;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class EmployeeController : Controller
    {
        private static readonly List<EmployeeView> _Employees = new List<EmployeeView>
        {
            new EmployeeView{Id = 1, FirstName = "Иван", SurName = "Иванов", Patronymic = "Иванович", Age = 19},
            new EmployeeView{Id = 2, FirstName = "Петр", SurName = "Петров", Patronymic = "Петрович", Age = 21},
            new EmployeeView{Id = 3, FirstName = "Олег", SurName = "Олегов", Patronymic = "Олегович", Age = 19}
        };

        public IActionResult Index()
        {
            return View(_Employees);
        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        public IActionResult Edit(EmployeeView EmployeInfo)
        {
            if (!ModelState.IsValid) return View(EmployeInfo);
            var employee = _Employees.FirstOrDefault(e => e.Id == EmployeInfo.Id);
            if (employee is null) return NotFound();
            employee.FirstName = EmployeInfo.FirstName;
            employee.SurName = EmployeInfo.SurName;
            employee.Patronymic = EmployeInfo.Patronymic;
            employee.Age = EmployeInfo.Age;
            return RedirectToAction(nameof(Details), new { id = EmployeInfo.Id });
        }
    }
}