using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;
        public HomeController(IConfiguration configuration) => _Configuration = configuration;
        public IActionResult Index() => View();
        public IActionResult GetConfig() => Content(_Configuration["CustomData"]);
    }
}