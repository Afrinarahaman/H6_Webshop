using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5_Webshop.Database.Entities;
using H5_Webshop.DTOs;
using H5_Webshop.Repositories;


namespace H5_Webshop.Services
{

    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrders();

        Task<OrderResponse> GetOrderById(int orderId);
        Task<List<OrderResponse>> GetOrdersByUserId(int user_Id);
        //Task<List<OrderResponse>> GetAllCategoriesWithoutProducts();
        Task<OrderResponse> CreateOrder(OrderRequest newOrder);
        //Task<OrderResponse> UpdateOrder(int orderId, OrderRequest updateOrder);
        //Task<OrderResponse> DeleteOrder(int orderId);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }


        public async Task<List<OrderResponse>> GetAllOrders()
        {
            List<Order> orders = await _orderRepository.SelectAllOrders();

            if (orders != null)
            {
                return orders.Select(order => MapOrderToOrderResponse(order)).ToList();
            }

            return null;
        }



        public async Task<OrderResponse> GetOrderById(int orderId)
        {
            Order order = await _orderRepository.SelectOrderById(orderId);

            if (order != null)
            {

                return MapOrderToOrderResponse(order);
            }
            return null;
        }
        public async Task<OrderResponse> CreateOrder(OrderRequest newOrder)
        {
            Order order = MapOrderRequestToOrder(newOrder);
            Order insertOrder = await _orderRepository.InsertNewOrder(order);


            if (insertOrder != null)
            {

                User user = await _userRepository.GetById(newOrder.UserId);
                insertOrder.User = user;
                return MapOrderToOrderResponse(insertOrder);

            }
            return null;
        }

        private Order MapOrderRequestToOrder(OrderRequest newOrder)
        {
            return new Order()
            {
                OrderDate = DateTime.Now,
                //OrderDate = newOrder.OrderDate,

                UserId = newOrder.UserId,
                OrderDetails = newOrder.OrderDetails.Select(x => new OrderDetails
                {
                    ProductId = x.ProductId,
                    ProductTitle = x.ProductTitle,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity

                }).ToList()

            };
        }

        private OrderResponse MapOrderToOrderResponse(Order order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                User = new UserResponse()
                {
                    Id = order.User.UserId,
                    Email = order.User.Email,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Address = order.User.Address,
                    Telephone = order.User.Telephone,
               },
                OrderDetails = order.OrderDetails.Select(order => new OrderDetailResponse
                {
                    Id = order.Id,
                    ProductId = order.ProductId,
                    ProductTitle = order.ProductTitle,
                    ProductPrice = order.ProductPrice,
                    Quantity = order.Quantity

                }).ToList()


            };


        }

        public async Task<List<OrderResponse>> GetOrdersByUserId(int user_Id)
        {
            List<Order> orders = await _orderRepository.SelectOrdersByUserId(user_Id);

            if (orders != null)
            {
                List<OrderResponse> responses = orders.Select(x => MapOrderToOrderResponse(x)).ToList();
                return responses;
            }
            return null;
        }
    }
}
