using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebsite.Data.Interfaces;
using CarWebsite.Data.Repositary;
using CarWebsite.Data.ViewModels;
using CarWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRep,ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

       
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
        };
            return View(obj);
        }





        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i=>i.id==id);
            if(item !=null)
            {
                _shopCart.AddtoCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}