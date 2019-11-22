using System.Collections.Generic;
using ASP_NET_Kurganskiy.Data;
using ASP_NET_Kurganskiy.Domain.Entities;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;

namespace ASP_NET_Kurganskiy.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSection() => TestData.Sections;
    }
}
