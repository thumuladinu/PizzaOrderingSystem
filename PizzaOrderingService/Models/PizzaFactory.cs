
using System;

namespace PizzaOrderingService.Models
{
    public class PizzaFactory
    {
        public static IPizza CreatePizza(string type)
        {
            return type.ToLower() switch
            {
                "margherita" => new MargheritaPizza(),
                "pepperoni" => new PepperoniPizza(),
                _ => throw new ArgumentException("Invalid pizza type")
            };
        }
    }
}
