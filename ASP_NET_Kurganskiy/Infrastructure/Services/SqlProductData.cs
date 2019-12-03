using ASP_NET.DAL.Context;
using ASP_NET_Kurganskiy.Domain.Entities;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.Infrastructure.Services
{
public class SqlProductData : IProductData //Unit of work
    {
        private readonly ASP_NET_Context _db;

        public SqlProductData(ASP_NET_Context db) => _db = db;


        public IEnumerable<Section> GetSections() => _db.Sections
           .Include(section => section.Products)
           .AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _db.Brands
           .Include(brand => brand.Products)
           .AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query.AsEnumerable(); /*query.ToArray();*/
        }

        public Product GetProductById(int? id) => _db.Products
            .Include(p => p.Brand)
            .Include(p => p.Section)
            .FirstOrDefault(p => p.Id == id);
    }
}
