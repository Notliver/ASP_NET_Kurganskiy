using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Kurganskiy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Kurganskiy.ViewModels
{
    public class EmployeeView
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name ="Фамилия")]
        public string SurName { get; set; }
        [Display(Name ="Отчество")]
        public string Patronymic { get; set; }
        [Display(Name ="Возраст")]
        public int Age { get; set; }


    }
}
