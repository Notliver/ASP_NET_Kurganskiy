using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using ASP_NET_Kurganskiy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        public readonly IProductData _ProductData;


        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;



        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandViewModel> GetBrands() => _ProductData
            .GetBrands()
            .Select(brand => new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                Order = brand.Order
            })
            .OrderBy(brand => brand.Order)
            .ToList();

    }
}
