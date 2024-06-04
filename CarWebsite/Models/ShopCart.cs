using CarWebsite.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCarId { get; set; }
        public List<ShopCardItem> listShopItems { get; set; } 

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();
            string ShopCardId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", ShopCardId);
            return new ShopCart(context) { ShopCarId = ShopCardId };    

        }
        public void AddtoCart(Car car)
        {
            appDBContent.ShopCardItem.Add(new ShopCardItem{
                ShopCarId=ShopCarId,
                car=car,
                prize= car.prize
                });
            appDBContent.SaveChanges();
        }
        public List<ShopCardItem> getShopItems()
        {
            return appDBContent.ShopCardItem.Where(c => c.ShopCarId == ShopCarId).Include(s => s.car).ToList();
        }


    }
}
