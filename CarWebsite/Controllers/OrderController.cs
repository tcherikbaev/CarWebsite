using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebsite.Data.Interfaces;
using CarWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();
            if(shopCart.listShopItems.Count==0)
            {
                ModelState.AddModelError("","у вас должны быть товары");
            }
            if(ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}