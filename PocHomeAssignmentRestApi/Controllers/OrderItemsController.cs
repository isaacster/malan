using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocHomeAssignmentRestApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocHomeAssignmentRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = ApiKeyAuthenticationOptions.Scheme)]
    public class OrderItemsController : ControllerBase
    {

        private readonly ILogger<OrderItemsController> _logger;

        private readonly IOrderItemsRepository _orderItemsRepository;

        public OrderItemsController(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsController> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }


        [HttpPost]
        [HttpPost("AddOrderItems")]
        public async Task<IActionResult> AddOrderItems(OrderItems orderItem)
        {
            if (orderItem == null)
            {
                return NoContent();
            }

            try
            {
               await _orderItemsRepository.AddOrderItem(orderItem);
            }
            catch (Exception ex)
            {

                
            }
            

            //OrderItems existingOrder = await _orderItemsRepository.GetOrderItem(orderItem.ProductName);
            //if (existingOrder == null)
            //{

            //    _orderItemsRepository.AddOrderItem(orderItem);

            //    return Ok("success");
            //}

            //update order 

            return Ok("success");
        }



        //[HttpPut("{token}")]
        //public async Task<IActionResult> UpdateOrderItem(int id, OrderItems orderItem)
        //{

        //    if (orderItem == null)
        //    {
        //        return NoContent();
        //    }

        //    OrderItems existingUser = await _orderItemsRepository.GetOrderItem(id);
        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }
        //    //user.ID = id;
        //    await _orderItemsRepository.UpdateOrderItem(orderItem);
        //    return NoContent();
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<OrderItems> data = await _orderItemsRepository.GetOrderItems();
            return Ok(data);
        }

        //[HttpGet("{token}")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    OrderItems user = await _orderItemsRepository.GetOrderItem(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

    }
}
