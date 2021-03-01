using System.Collections.Generic;

namespace PizzaPizzaz
{
    class Pizza
    {
        public string Name { get; set; }
        public List<Topping> Toppings { get; set; }

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>(); 
        }
    }
}
