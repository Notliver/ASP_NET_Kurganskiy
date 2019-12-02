using ASP_NET.DAL.Context;
using ASP_NET_Kurganskiy.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.Data
{
    public class ASP_NET_KurganskiyContextInitializer
    {
        private readonly ASP_NET_Context _db;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;

        public ASP_NET_KurganskiyContextInitializer(ASP_NET_Context db, UserManager<User> UserManager, RoleManager<Role> RoleManager)
        {
            _db = db;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }

        public async Task InitializeAsync()
        {
            var db = _db.Database;
            //if (await db.EnsureDeletedAsync())
            //{
            //    база данных удалена
            //}

            //db.EnsureCreatedAsync(); // Создаем базу данных

            await db.MigrateAsync(); // Автоматическое создание и миграция базы до последней версии

            await IdentityInitializeAsync();

            if (await _db.Products.AnyAsync()) return;

            using (var transaction = await db.BeginTransactionAsync())
            {
                await _db.Sections.AddRangeAsync(TestData.Sections);

                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Sections] ON"); //Нужно т.к. мы проставили ID вручную.(База сама всегда указывает ID) Первичными ключами
                await _db.SaveChangesAsync();
                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Sections] OFF"); //Закрываем запись первичных ключей.

                transaction.Commit();

            }

            using (var transaction = await db.BeginTransactionAsync())
            {
                await _db.Brands.AddRangeAsync(TestData.Brands);

                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Brands] ON"); //Нужно т.к. мы проставили ID вручную.(База сама всегда указывает ID) Первичными ключами
                await _db.SaveChangesAsync();
                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Brands] OFF"); //Закрываем запись первичных ключей.

                transaction.Commit();

            }
            using (var transaction = await db.BeginTransactionAsync())
            {
                await _db.Products.AddRangeAsync(TestData.Products);

                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Products] ON"); //Нужно т.к. мы проставили ID вручную.(База сама всегда указывает ID) Первичными ключами
                await _db.SaveChangesAsync();
                await db.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Products] OFF"); //Закрываем запись первичных ключей.

                transaction.Commit();


            }
        }
        private async Task IdentityInitializeAsync()
        {
            if (!await _RoleManager.RoleExistsAsync(Role.Administrator))
            {
                await _RoleManager.CreateAsync(new Role { Name = Role.Administrator });
            }

            if (!await _RoleManager.RoleExistsAsync(Role.User))
            {
                await _RoleManager.CreateAsync(new Role { Name = Role.User });
            }

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator,
                    //Email = "admin@server.com"

                };
                var creation_result = await _UserManager.CreateAsync(admin, User.AdminPasswordDefault);

                if (creation_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                else
                    throw new InvalidOperationException($"Ошибка при создании администратора в БД {string.Join(",", creation_result.Errors.Select(e => e.Description))}");
            }
        }

    }
}
