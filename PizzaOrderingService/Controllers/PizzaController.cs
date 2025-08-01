
using Microsoft.AspNetCore.Mvc;
using PizzaOrderingService.Models;

namespace PizzaOrderingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet("{type}")]
        public IActionResult GetPizza(string type)
        {
            try
            {
                var pizza = PizzaFactory.CreatePizza(type);
                return Ok(new { Pizza = pizza.GetDetails() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
