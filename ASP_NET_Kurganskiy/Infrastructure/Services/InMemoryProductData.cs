using System.Collections.Generic;
using System.Linq;
using ASP_NET_Kurganskiy.Data;
using ASP_NET_Kurganskiy.Domain.Entities;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;

namespace ASP_NET_Kurganskiy.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public Product GetProductById(int? id) => TestData.Products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);
            
            return query;
        }

        public IEnumerable<Section> GetSections() => TestData.Sections;
    }
}
