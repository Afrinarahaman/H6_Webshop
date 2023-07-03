using H5_Webshop.Database;
using H5_Webshop.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Repositories
{
   
        public interface IOrderRepository
        {
            Task<List<Order>> SelectAllOrders();
            Task<Order> SelectOrderById(int orderId);
            Task<List<Order>> SelectOrdersByUserId(int user_Id);
            //Task<List<Order>> SelectAllOrdersWithoutProducts();
            // Task<List<Order>> SelectCategoriesByProductId(int productId);
            Task<Order> InsertNewOrder(Order orderId);
            //Task<Order> UpdateExistingOrder(int orderId, Order order);
            //Task<Order> DeleteOrderById(int orderId);

        }


        public class OrderRepository : IOrderRepository
        {
            private readonly WebshopApiContext _context;

            public OrderRepository(WebshopApiContext context)
            {
                _context = context;
            }
            public async Task<List<Order>> SelectAllOrders()
            {
                try
                {
                    return await _context.Order
                             .Include(o => o.User)
                             .Include(o => o.OrderDetails).ThenInclude(x => x.Product)

                              .ToListAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            public async Task<List<Order>> SelectOrdersByUserId(int user_Id)
            {
                try
                {
                    return await _context.Order
                        .Include(o => o.User)
                             .Include(o => o.OrderDetails).ThenInclude(x => x.Product).Where(c => c.UserId== user_Id)

                              .ToListAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public async Task<Order> SelectOrderById(int orderId)
            {
                try
                {
                    return await _context.Order
                        .Include(a => a.OrderDetails).ThenInclude(a => a.Product)
                        // .Include(a => a.OrderDetails).ThenInclude(a => a.Order)
                        .Include(c => c.User)
                        .FirstOrDefaultAsync(order => order.Id == orderId);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public async Task<Order> InsertNewOrder(Order order)
            {

                _context.Order.Add(order);
                await _context.SaveChangesAsync();
                return order;



            }
            public async Task<Order> DeleteOrderById(int orderId)
            {
                var deleteOrder = await _context.Set<Order>().FirstOrDefaultAsync(o => o.Id == orderId);
                try
                {
                    if (deleteOrder != null)
                    {
                        _context.Remove(deleteOrder);
                        await _context.SaveChangesAsync();

                    }

                    return deleteOrder;
                }
                catch (Exception)
                {
                    return null;
                }
            }



            public async Task<Order> UpdateExistingOrder(int orderId, Order order)
            {


                try
                {
                    //order.Customer = null;
                    _context.Update(order);


                    await _context.SaveChangesAsync();

                    return await _context.Order.FirstOrDefaultAsync(order => order.Id == orderId);
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
    
}
