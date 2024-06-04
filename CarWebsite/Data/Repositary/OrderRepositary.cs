using CarWebsite.Data.Interfaces;
using CarWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Data.Repositary
{
    public class OrderRepositary : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrderRepositary(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();


            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var OrderDetail = new orderDetails()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = el.car.prize
                };
                appDBContent.OrderDetails.Add(OrderDetail);
            }
            appDBContent.SaveChanges();
        }

    }
}
