using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Kurganskiy.Domain.Entities;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using ASP_NET_Kurganskiy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class CatalogController : Controller
    {
        public readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? SectionId, int? BrandId)
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId
            });

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products= products.Select(p=> new ProductViewModel
                {
                    Id=p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).OrderBy(p => p.Order)
            });
     
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}