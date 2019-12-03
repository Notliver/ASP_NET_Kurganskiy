using ASP_NET_Kurganskiy.Domain.Entities;
using System.Collections.Generic;

namespace ASP_NET_Kurganskiy.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int? id);

    }
}
