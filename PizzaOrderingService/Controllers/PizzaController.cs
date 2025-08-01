using Microsoft.AspNetCore.Mvc;
using PizzaOrderingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private static readonly List<string> PizzaTypes = new() { "margherita", "pepperoni", "veggie", "bbqchicken" };
        private static readonly List<string> Areas = new() { "colombo", "kandy", "galle", "negombo" };
        private static readonly List<Order> Orders = new();

        [HttpGet("types")]
        public IActionResult GetPizzaTypes() => Ok(PizzaTypes);

        [HttpGet("areas")]
        public IActionResult GetAreas() => Ok(Areas);

        [HttpPost("order")]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            if (!PizzaTypes.Contains(order.PizzaType.ToLower()))
                return BadRequest("Invalid pizza type.");
            if (!Areas.Contains(order.Area.ToLower()))
                return BadRequest("Invalid area.");

            Orders.Add(order);
            return Ok(new { Message = "Order placed successfully", OrderId = order.Id });
        }

        [HttpDelete("order/{id}")]
        public IActionResult CancelOrder(Guid id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound("Order not found.");

            order.Status = "Cancelled";
            return Ok(new { Message = "Order cancelled", Order = order });
        }
    }
}
