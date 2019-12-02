using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Kurganskiy.Domain.Entities.Identity;
using ASP_NET_Kurganskiy.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<AccountController> _Logger;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager, ILogger<AccountController> Logger)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _Logger = Logger;
        }

        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if(ModelState.IsValid)
                return View(Model);

            var login_result = await _SignInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
                false);

            if(login_result.Succeeded)
            {
                
                _Logger.LogInformation($"Пользователь {Model.UserName} успешно авторизовался");
                if (Url.IsLocalUrl(Model.ReturnUrl))
                    return Redirect(Model.ReturnUrl);
                return RedirectToAction("index", "Home");
            }

            ModelState.AddModelError("", "Неверное имя пользователя или пароль");

            _Logger.LogWarning($"Ошибка при входе пользователя {Model.UserName} в систему");
            return View(Model);
        }

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel Model)
        {
            if (ModelState.IsValid)
                return View(Model);

            var user = new User
            {
                UserName = Model.UserName
            };
            _Logger.LogInformation($"Регистрация нового пользователя {Model.UserName}");

            var registration_result = await _UserManager.CreateAsync(user, Model.Password);
            if(registration_result.Succeeded)
            {
                await _UserManager.AddToRoleAsync(user, Role.User);
                _Logger.LogInformation($"Пользователь {Model.UserName} успешно зарегистрирован");
                await _SignInManager.SignInAsync(user, false);
                _Logger.LogInformation($"Пользователь {Model.UserName} зашел в систему");
                return RedirectToAction("index", "Home");
            }

            foreach (var error in registration_result.Errors)
                ModelState.AddModelError("", error.Description);

            _Logger.LogWarning($"Ошибка при регистрации пользователя {Model.UserName} : {string.Join(' ', registration_result.Errors.Select(e => e.Description))}");

            return View(Model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            var user_name = User.Identity.Name;
            await _SignInManager.SignOutAsync();
            _Logger.LogInformation($"Пользователь {user_name} успешно вышел из системы");
            return RedirectToAction("Index", "Home");
        }
    }
}