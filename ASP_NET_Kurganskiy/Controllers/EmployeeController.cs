﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Kurganskiy.ViewModels;
using ASP_NET_Kurganskiy.Infrastructure.Services;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ASP_NET_Kurganskiy.Domain.Entities.Identity;

namespace ASP_NET_Kurganskiy.Controllers
{
    //[Route("Users")]
    [Authorize]
    public class EmployeeController : Controller
        
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeeController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;
        
        public IActionResult Index()
        {

            return View(_EmployeesData.GetAll());
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

        public IActionResult Create() => View(new EmployeeView());

        [HttpPost]
        public IActionResult Create(EmployeeView NewEmployee)
        {
            if (!ModelState.IsValid)
                return View(NewEmployee);

            _EmployeesData.Add(NewEmployee);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Details", new { NewEmployee.Id });
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new EmployeeView());

            if (Id < 0) return BadRequest();
            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentOutOfRangeException(nameof(Employee));

           if(Employee.Age < 18)
            {
                ModelState.AddModelError(nameof(EmployeeView.Age), "Ограничение возрастной группы 18+");

            }

           if(Employee.FirstName == "123" && Employee.SurName == "qwe")
            {
                ModelState.AddModelError("", "Подозрительно");
            }
            
            if (!ModelState.IsValid)
                return View(Employee);

 

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(Employee);
            else
                _EmployeesData.Edit(id, Employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int Id)
        {
            _EmployeesData.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}