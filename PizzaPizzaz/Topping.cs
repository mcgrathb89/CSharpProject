namespace PizzaPizzaz
{
    class Topping
    {
        public string ToppingA { get; set; }
        public string ToppingB { get; set; }
        public string ToppingC { get; set; } 
        public string ToppingD { get; set; }
        public string ToppingCost { get; set; }

        public string JoinToppingNames => $"{ToppingA}, {ToppingB}, {ToppingC}, {ToppingD} {ToppingCost}"; 

        public Topping(string toppingOne, string toppingTwo, string toppingThree, string toppingFour, string toppingCost)
        {
            ToppingA = toppingOne;
            ToppingB = toppingTwo;
            ToppingC = toppingThree;
            ToppingD = toppingFour;
            ToppingCost = toppingCost;
        }
    }
}
