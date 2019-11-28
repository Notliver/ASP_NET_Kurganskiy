using System.Collections.Generic;
using System.Text;
using ASP_NET_Kurganskiy.Domain.Entities;
using ASP_NET_Kurganskiy.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET.DAL.Context
{
    public class ASP_NET_Context : IdentityDbContext<User, Role, string>
    {
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Product> Products { get; set; }

        public ASP_NET_Context(DbContextOptions<ASP_NET_Context> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    base.OnModelCreating(model);
        //}
    }
}
