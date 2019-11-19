using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index() => View();
        public IActionResult Blog() => View();
        public IActionResult BlogSingle() => View();
        public IActionResult Cart() => View();
        public IActionResult CheckOut() => View();
        public IActionResult ContactUs() => View();
        public IActionResult Login() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult Shop() => View();
        public IActionResult Error404() => View();

        public IActionResult TestAction()
        {
            //return new ViewResult(); //Ручное создание "представление" --Альтернативна вызова View
            //return View();


            //return new JsonResult(new { Customer = "Иванов", Id = 15, Date = DateTime.Now})
            //return Json(new { Customer = "Иванов", Id = 15, Date = DateTime.Now })


            //return Redirect("http://www.ya.ru"); 
            //return new RedirectResult("http://www.ya.ru");


            //return new RedirectToActionResult("Index", "Employees", null);
            return RedirectToAction("Index", "Employees");

            //return Content("Hello world");
            //return new ContentResult { Content = "Hello World", ContentType = "application/text" };


            //return File(Encoding.UTF8.GetBytes("Hello World!"), "application/text", "HelloWorld.txt");
            //return new FileContentResult(Encoding.UTF8.GetBytes("Hello world!"), new MediaTypeHeaderValue("application/text"));

            //return new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes("Hello World!")), "application/");

            return StatusCode(405);
            return new StatusCodeResult(500);
            return NoContent();
            return new NoContentResult();
        }




    }
}