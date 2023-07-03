using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5_Webshop.DTOs;
using H5_Webshop.Services;

namespace H5_Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                List<OrderResponse> orderResponses = await _orderService.GetAllOrders();
                if (orderResponses == null)
                {
                    return Problem("Got no data, not even an empty list, this is unexpected");
                }
                if (orderResponses.Count == 0)
                {
                    return NoContent();
                }
                return Ok(orderResponses);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);

            }


        }
        // https://localhost:5001/api/Product/derp
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            try
            {
                OrderResponse orderResponses = await _orderService.GetOrderById(orderId);

                if (orderResponses == null)
                {
                    return NotFound();
                }

                return Ok(orderResponses);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
        // https://localhost:5001/api/Product/derp

        [HttpGet("User/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrdersByCustomerId([FromRoute] int user_Id)
        {
            try
            {
                List<OrderResponse> orderResponse = await _orderService.GetOrdersByUserId(user_Id);
                if (orderResponse == null)
                {
                    return Problem("Got no data, not even an empty list, this is unexpected");
                }
                if (orderResponse.Count == 0)
                {
                    return NoContent();
                }
                return Ok(orderResponse);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);

            }


        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] OrderRequest newOrder)
        {
            try
            {
                OrderResponse orderResponse = await _orderService.CreateOrder(newOrder);

                if (orderResponse == null)
                {
                    return NotFound();
                }

                return Ok(orderResponse);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }



    }
}
