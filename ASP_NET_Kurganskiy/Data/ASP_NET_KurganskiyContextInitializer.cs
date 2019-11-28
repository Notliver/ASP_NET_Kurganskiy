using ASP_NET.DAL.Context;
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

        public ASP_NET_KurganskiyContextInitializer(ASP_NET_Context db) => _db = db;

        public async Task InitializeAsync()
        {
            var db = _db.Database;
            //if (await db.EnsureDeletedAsync())
            //{
            //    база данных удалена
            //}

            //db.EnsureCreatedAsync(); // Создаем базу данных

            await db.MigrateAsync(); // Автоматическое создание и миграция базы до последней версии

            if (await _db.Products.AnyAsync()) return;

            using (var transaction = _db.Database.BeginTransaction())
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
    }
}
