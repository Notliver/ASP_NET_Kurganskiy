using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Kurganskiy.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Kurganskiy.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        public CartController(ICartService CartService) => _CartService = CartService;

        public IActionResult Details() => View(_CartService.TransformFromCart());

        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult DecrimentFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll(int id)
        {
            _CartService.RemoveAll();
            return RedirectToAction("Details");
        }
    }
}