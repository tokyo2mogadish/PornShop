using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PornDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ShoppingCart shoppingCart, PornDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Pie.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }
    }
}
