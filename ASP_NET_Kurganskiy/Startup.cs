using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ASP_NET_Kurganskiy.Infrastructure.Conventions;
using ASP_NET_Kurganskiy.Infrastructure.Services;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ASP_NET.DAL.Context;
using ASP_NET_Kurganskiy.Data;
using Microsoft.AspNetCore.Identity;
using ASP_NET_Kurganskiy.Domain.Entities.Identity;

namespace ASP_NET_Kurganskiy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Config) => Configuration = Config;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ASP_NET_Context>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ASP_NET_KurganskiyContextInitializer>();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            //services.AddScoped<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();


            //Подключаем авторизацию по Юзеру и Роли
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ASP_NET_Context>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 3;//Длина пароля
                opt.Password.RequireDigit = false;//Требование цифр
                opt.Password.RequireUppercase = false;//Требование верхнего регистра
                opt.Password.RequireLowercase = false;//Требование нижнего
                opt.Password.RequireNonAlphanumeric = false;//Требование не алфавитного символа
                opt.Password.RequiredUniqueChars = 3;//Должно быть кол-во уникальных символов

                opt.Lockout.AllowedForNewUsers = true;//блокирует доступ новых пользователей, пока администратор их не разблокирует. Создавать можно.
                opt.Lockout.MaxFailedAccessAttempts = 10;// Максимальное кол-во попыток входа
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//Кулдаун при израсходовании кол-ва попыток

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; //Список допустимых символов для создания пользователя
                opt.User.RequireUniqueEmail = false; /*Требование к уникальности e-mail 
                                                       При отладке необходимо отключить, т.к. при содании пользователя мы не будем указывать почту 
                                                       и как следствие второго пользователя не сможем уже создать*/
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "Kurganskiy-Identity";//Определяем под каким именем будем сохранять кукиз
                opt.Cookie.HttpOnly = true; //Указываем что передача кукиз возможна только по HTTP
                opt.Cookie.Expiration = TimeSpan.FromDays(150); //Время жизни кукиз

                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Accont/Logout";
                opt.AccessDeniedPath = "Account/AccessDenided";

                opt.SlidingExpiration = true;//Авторизуется, отслеживание

                
            });

            //services.AddSingleton<TInterface, TImplementation>(); //- Единый объект на все время жизни приложения с момента первого обращения к нему
            //services.AddTransient<>(); // - Один объек на каждый запрос экземпляра сервиса
            //services.AddScoped<>(); // - Один оъект на время одного входящего запроса(на время действия области)
            services.AddSession();

            services.AddMvc(
                opt =>
                {
                    //opt.Conventions.Add(new CustomControllerConvention());
                });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ASP_NET_KurganskiyContextInitializer db)
        {
            db.InitializeAsync().Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink(); 
            }

            app.UseStaticFiles(/*new StaticFileOptions { ServeUnknownFileTypes = true }*/);
            app.UseDefaultFiles();
            app.UseCookiePolicy();

            app.UseAuthentication(); //Подключили Identity все что выше не требует авторизации, все что ниже требует

            //app.UseAuthentication();
            app.UseSession();
            //app.UseResponseCaching();
            //app.UseResponseCompression();



            //app.UseWelcomePage("/welcome");   //Пример промежуточного ПО

            //app.Run(async context => await context.Response.WriteAsync("Hello World!")); //Безусловное выполнение ( замыкает конвейер) 

            //app.Map("/Hello", application => application.Run(async context => await context.Response.WriteAsync("Hello World!")));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
