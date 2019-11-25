using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace ASP_NET_Kurganskiy.ViewModels
{
    public class EmployeeView
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage ="Поле должно быть заполнено", AllowEmptyStrings =false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage ="Имя должно состоять минимум из 2 символов")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A - Z][a - z] +)", ErrorMessage = "Странное имя")]
        public string FirstName { get; set; }
        [Display(Name ="Фамилия")]
        [Required(ErrorMessage ="Поле должно быть заполнено", AllowEmptyStrings =false)]
        [StringLength(200, MinimumLength =3, ErrorMessage ="Фамилия должна состоять минимум из 3 символов")]
        public string SurName { get; set; }
        [Display(Name ="Отчество")]
        public string Patronymic { get; set; }
        [Display(Name ="Возраст")]
        [Required(ErrorMessage ="Не указан возраст", AllowEmptyStrings = false)]
        public int Age { get; set; }


    }
}
