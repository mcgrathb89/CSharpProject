using System;
using System.Collections.Generic;
using System.IO;

namespace PizzaPizzaz
{
    public class App
    {
        public static string AdminUsername = "Bobby";
        public static decimal PizzaCost
        {
            get; set;
        }
        public static decimal PizzaProductionCost { get; set; }
        public static decimal GrossProfit { get; set; } 
        public static string PizzaSize { get; set; }
        public static string BaseType { get; set; }
        public static string BaseSauceChoice { get; set; }
        public static string PizzaChoice { get; set; }
        public static string CrustType { get; set; }
        public static string StarterAdd { get; set; }
        public static string AddDrink { get; set; }
        public static string AddDesert { get; set; }
        public static string CustomerFirstName { get; set; }
        public static string CustomerLastName { get; set; }
        public static string CardName { get; set; }
        public static string CardNumber { get; set; }
        public static string SortCode { get; set; }
        public static string ExpiryDate { get; set; }
        public static string FirstLineOfAddress { get; set; }
        public static string Postcode { get; set; }
        public static string DeliveryPreference { get; set; }
        public static string DeliveryStatus { get; set; } 
        public static string ContactNumber { get; set; } 
        public static List<string> ExtraTopping { get; set; } = new List<string>();

        public void Run()
        {
            File.Delete("Address.txt");
            File.Delete("Extras.txt"); 
            File.Delete("Receipt.txt"); 
            PizzaCost = 0;
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.CursorVisible = false;
            bool loop = true;
            do
            {
                //    PizzaCost = 0;
                //    ExtraTopping.Clear();
                DateTimeMenu();
                Console.WriteLine(" Chose an Option\n ---------------\n\n 1. Use Existing Pizza\n 2. Create Pizza\n 3. Update Pizza Status\n 4. Admin - Pizza Cost Information\n 5. Admin - Delete Current Order Data\n 6. Exit");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1)
                {

                    DateTimeMenu();
                    Console.WriteLine(" Choose a Size\n -------------\n\n 1. Small\n 2. Medium\n 3. Large\n 4. Back to Main Menu\n");
                    Pizzas();
                }

                else if (keyInfo.Key == ConsoleKey.D2)
                {

                    DateTimeMenu();
                    Console.WriteLine(" Choose a Size\n -------------\n\n 1. Small - £5.00\n 2. Medium - £7.50\n 3. Large - £10.00\n 4. Back to Main Menu\n"); 
                    CustomPizza();
                }

                else if (keyInfo.Key == ConsoleKey.D3)
                {
                    OrderStatus();
                }

                else if (keyInfo.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("\n\n NOTE - Don't Login Until The Current Order Has Been Marked As Delivered");
                    PizzaCostInformation();
                }

                else if (keyInfo.Key == ConsoleKey.D5)
                {
                    AdminLogin();
                    PizzaCost = 0;
                    Console.WriteLine("\n\n\n Pizza Cost Information Deleted - Press Any Key To Continue..."); 
                    Console.ReadKey(true);
                }

                else if (keyInfo.Key == ConsoleKey.D6)
                {
                    Console.Write("\n\n Are You Sure You Wish to Exit? Y/N: ");

                    ConsoleKeyInfo userKey = Console.ReadKey();

                    if (userKey.Key == ConsoleKey.Y)
                    {
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }

                    else if (userKey.Key == ConsoleKey.N)
                    {
                        Console.ReadKey(true);
                        loop = false;
                    }
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (loop);
        }
        public static void DateTimeMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t   -|- PizzaPizzaz -|-\n\n");
            Console.WriteLine(" Current Date & Time: " + DateTime.Now + "\n\n");
        }
        public static void Pizzas()
        { 
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            if (userInput.Key == ConsoleKey.D1)
            {
                PizzaSize = "Small";
                Pizza pizzaOne = new Pizza("1. Mighty Meaty");
                pizzaOne.Toppings.Add(new Topping("Ham", "Pepperoni", "Sausage", "Salami", " - £5.00"));
                Pizza pizzaTwo = new Pizza("2. Hawaiian");
                pizzaTwo.Toppings.Add(new Topping("Ham", "Pineapple", "Tomato", "Mushroom", " - £5.00"));
                Pizza pizzaThree = new Pizza("3. Brunch Banger");
                pizzaThree.Toppings.Add(new Topping("Extra Cheese", "Sausage", "Bacon", "Egg", " - £7.50"));
                Pizza pizzaFour = new Pizza("4. Fiery Fajita");
                pizzaFour.Toppings.Add(new Topping("Extra Cheese", "Chicken", "Mixed Peppers", "Jalapeño", "- £7.50"));
                Pizza pizzaFive = new Pizza("5. Bombay Blast Off");
                pizzaFive.Toppings.Add(new Topping("Paneer Cheese", "Tandoori Chicken", "Coriander", "Spring Onions"," - £10.00"));
                Pizza pizzaSix = new Pizza("6. Philly Cheesesteak");
                pizzaSix.Toppings.Add(new Topping("Extra Cheese", "Beef", "cheese Sauce", "Onions", " - £10.00"));
                List<Pizza> pizzas =
                    new List<Pizza> {pizzaOne, pizzaTwo, pizzaThree, pizzaFour, pizzaFive, pizzaSix};
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine(" Choose a Pizza\n --------------");

                foreach (var pizza in pizzas)
                {
                    foreach (var topping in pizza.Toppings)
                    {
                        Console.WriteLine("\n {0}: {1}", pizza.Name, topping.JoinToppingNames);
                    }
                }


                if (userInput.Key == ConsoleKey.D1)
                {
                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D3)
                {

                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D4)
                {
                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D5)
                {
                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D6)
                {
                    SmallPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadLine();
                }
            }
            else if (userInput.Key == ConsoleKey.D2)
            {
                PizzaSize = "Medium";
                Pizza pizzaOne = new Pizza("1. Mighty Meaty");
                pizzaOne.Toppings.Add(new Topping("Ham", "Pepperoni", "Sausage", "Salami", " - £7.50"));
                Pizza pizzaTwo = new Pizza("2. Hawaiian");
                pizzaTwo.Toppings.Add(new Topping("Ham", "Pineapple", "Tomato", "Mushroom", " - £7.50"));
                Pizza pizzaThree = new Pizza("3. Brunch Banger");
                pizzaThree.Toppings.Add(new Topping("Extra Cheese", "Sausage", "Bacon", "Egg", " - £10.00"));
                Pizza pizzaFour = new Pizza("4. Fiery Fajita");
                pizzaFour.Toppings.Add(new Topping("Extra Cheese", "Chicken", "Mixed Peppers", "Jalapeño",
                    "- £10.00"));
                Pizza pizzaFive = new Pizza("5. Bombay Blast Off");
                pizzaFive.Toppings.Add(new Topping("Paneer Cheese", "Tandoori Chicken", "Coriander", "Spring Onions", " - £12.00"));
                Pizza pizzaSix = new Pizza("6. Philly Cheesesteak");
                pizzaSix.Toppings.Add(new Topping("Extra Cheese", "Beef", "cheese Sauce", "Onions", " - £12.00"));
                List<Pizza> pizzas =
                    new List<Pizza> {pizzaOne, pizzaTwo, pizzaThree, pizzaFour, pizzaFive, pizzaSix};
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine(" Choose a Pizza\n --------------");

                foreach (var pizza in pizzas)
                {
                    foreach (var topping in pizza.Toppings)
                    {
                        Console.WriteLine("\n {0}: {1}", pizza.Name, topping.JoinToppingNames);
                    }
                }

                if (userInput.Key == ConsoleKey.D1)
                {
                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D3)
                {

                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D4)
                {
                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D5)
                {
                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D6)
                {
                    MediumPizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadLine();
                }

            }
            else if (userInput.Key == ConsoleKey.D3)
            {
                PizzaSize = "Large";
                Pizza pizzaOne = new Pizza("1. Mighty Meaty");
                pizzaOne.Toppings.Add(new Topping("Ham", "Pepperoni", "Sausage", "Salami", " - £10.00"));
                Pizza pizzaTwo = new Pizza("2. Hawaiian");
                pizzaTwo.Toppings.Add(new Topping("Ham", "Pineapple", "Tomato", "Mushroom", " - £10.00"));
                Pizza pizzaThree = new Pizza("3. Brunch Banger");
                pizzaThree.Toppings.Add(new Topping("Extra Cheese", "Sausage", "Bacon", "Egg", " - £12.00"));
                Pizza pizzaFour = new Pizza("4. Fiery Fajita");
                pizzaFour.Toppings.Add(new Topping("Extra Cheese", "Chicken", "Mixed Peppers", "Jalapeño", "- £12.00"));
                Pizza pizzaFive = new Pizza("5. Bombay Blast Off");
                pizzaFive.Toppings.Add(new Topping("Paneer Cheese", "Tandoori Chicken", "Coriander", "Spring Onions", " - £15.00"));
                Pizza pizzaSix = new Pizza("6. Philly Cheesesteak");
                pizzaSix.Toppings.Add(new Topping("Extra Cheese", "Beef", "Cheese Sauce", "Onions", " - £15.00"));
                List<Pizza> pizzas =
                    new List<Pizza> {pizzaOne, pizzaTwo, pizzaThree, pizzaFour, pizzaFive, pizzaSix};
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine(" Choose a Pizza\n --------------");

                foreach (var pizza in pizzas)
                {
                    foreach (var topping in pizza.Toppings)
                    {
                        Console.WriteLine("\n {0}: {1}", pizza.Name, topping.JoinToppingNames);
                    }
                }

                if (userInput.Key == ConsoleKey.D1)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D4)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D5)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Sides();
                    Drink();
                    Dessert();
                }

                else if (userInput.Key == ConsoleKey.D6)
                {
                    LargePizzaChoice();
                    Crusts();
                    Base();
                    BaseSauce();
                    Toppings();
                    Drink();
                    Dessert();
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadLine();
                }

            }
            else if (userInput.Key == ConsoleKey.D4)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void CustomPizza()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            if (userInput.Key == ConsoleKey.D1)
            {
                PizzaCost += 5.0m;
                PizzaSize = "Small";
                Crusts();
                Base();
                BaseSauce();
                CustomToppings();
                Sides();
                Drink();
                Dessert();
            }
            else if (userInput.Key == ConsoleKey.D2)
            {
                PizzaCost += 7.5m;
                PizzaSize = "Medium";
                Crusts();
                Base();
                BaseSauce();
                CustomToppings();
                Sides();
                Drink();
                Dessert();
            }

            else if (userInput.Key == ConsoleKey.D3)
            {
                PizzaCost += 10.0m;
                PizzaSize = "Large"; 
                Crusts();
                Base();
                BaseSauce();
                CustomToppings();
                Sides();
                Drink();
                Dessert();
            }
        }
        public static void Crusts()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Choose Crust\n ------------\n\n 1. Standard Crust - £0.00\n 2. Cheese Stuffed Crust - £2.50\n 3. Marinara Stuffed Crust - £2.00");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.D1)
                {
                    PizzaCost += 0m;
                    CrustType = "Standard Crust";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    PizzaCost += 2.5m;
                    CrustType = "Cheese Stuffed Crust";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    PizzaCost += 2m;
                    CrustType = "Marinara Stuffed Crust";
                    loop = false;
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    Console.ReadKey(true);
                }

            } while (loop);
        }
        public static void Base()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Choose a Base\n -------------\n\n 1. Standard - £0.00\n 2. Thin 'n' Crispy - £0.50\n 3. Garlic and Herb - £1.00");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.D1)
                {
                    PizzaCost += 0m;
                    BaseType = "Standard Base";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    PizzaCost += 0.50m;
                    BaseType = "Thin 'n' Crispy";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    PizzaCost += 1.00m;
                    BaseType = "Garlic and Herb";
                    loop = false;
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    Console.ReadKey(true);
                }
            } while (loop);
        }
        public static void BaseSauce()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Choose Base Sauce\n -----------------\n\n 1. Marinara - £0.00\n 2. BBQ - £1.00\n 3. Sundried Tomato, Garlic and Herb - £1.50");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.D1)
                {
                    PizzaCost += 0m;
                    BaseSauceChoice = "Marinara";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    PizzaCost += 1.00m;
                    BaseSauceChoice = "BBQ";
                    loop = false;
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    PizzaCost += 1.50m;
                    BaseSauceChoice = "Sundried Tomato, Garlic and Herb";
                    loop = false;
                }
                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    Console.ReadKey(true);
                }
            } while (loop);
        }
        public static void SmallPizzaChoice()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                    PizzaCost += 5m;
                    PizzaChoice = "Mighty Meaty";
                    break;
                case ConsoleKey.D2:
                    PizzaCost += 5m;
                    PizzaChoice = "Hawaiian";
                    break;
                case ConsoleKey.D3:
                    PizzaCost += 7.5m;
                    PizzaChoice = "Brunch Banger";
                    break;
                case ConsoleKey.D4:
                    PizzaCost += 7.5m;
                    PizzaChoice = "Fiery Fajita";
                    break;
                case ConsoleKey.D5:
                    PizzaCost += 10m;
                    PizzaChoice = " Bombay Blast Off";
                    break;
                case ConsoleKey.D6:
                    PizzaCost += 10m;
                    PizzaChoice = "Philly Cheesesteak";
                    break;
                default:
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
            }
        }
        public static void MediumPizzaChoice()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                    PizzaCost += 7.5m;
                    PizzaChoice = "Mighty Meaty";
                    break;
                case ConsoleKey.D2:
                    PizzaCost += 7.5m;
                    PizzaChoice = "Hawaiian";
                    break;
                case ConsoleKey.D3:
                    PizzaCost += 10m;
                    PizzaChoice = "Brunch Banger";
                    break;
                case ConsoleKey.D4:
                    PizzaCost += 10m;
                    PizzaChoice = "Fiery Fajita";
                    break;
                case ConsoleKey.D5:
                    PizzaCost += 12m;
                    PizzaChoice = " Bombay Blast Off";
                    break;
                case ConsoleKey.D6:
                    PizzaCost += 12m;
                    PizzaChoice = "Philly Cheesesteak";
                    break;
                default:
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
            }
        }
        public static void LargePizzaChoice()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                    PizzaCost += 10m;
                    PizzaChoice = "Mighty Meaty";
                    break;
                case ConsoleKey.D2:
                    PizzaCost += 10m;
                    PizzaChoice = "Hawaiian";
                    break;
                case ConsoleKey.D3:
                    PizzaCost += 12m;
                    PizzaChoice = "Brunch Banger";
                    break;
                case ConsoleKey.D4:
                    PizzaCost += 12m;
                    PizzaChoice = "Fiery Fajita";
                    break;
                case ConsoleKey.D5:
                    PizzaCost += 15m;
                    PizzaChoice = " Bombay Blast Off";
                    break;
                case ConsoleKey.D6:
                    PizzaCost += 15m;
                    PizzaChoice = "Philly Cheesesteak";
                    break;
                default:
                    Console.WriteLine("\n\n Incorrect Input - Press Enter to Return to Main Menu Then Try Again...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
            }
        }
        public static void Toppings()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Extras\n ------");
                Console.Write("\n Add Extra Toppings? Y/N: ");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                {
                    if (userInput.Key == ConsoleKey.Y)
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            DateTimeMenu();
                            Console.WriteLine("\n Add Additional Toppings (Maximum of Three)\n ------------------------------------------\n\n - NOTE: Each topping is £1.50 -\n\n Press ESC to Stop Adding Extra Toppings\n\n 1. Sausage\n 2. Bacon\n 3. Mushroom\n 4. Egg\n 5. Ham\n 6. Pineapple\n 7. Mixed Peppers\n 8. Jalapeño\n 9. Extra Cheese");
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);

                            ConsoleKeyInfo toppingInfo = Console.ReadKey(true);

                            if (toppingInfo.Key == ConsoleKey.Escape)
                            {
                                break;
                            }

                            if (toppingInfo.Key == ConsoleKey.D1)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Sausage");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D2)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Bacon");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D3)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Mushroom");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D4)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Egg");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D5)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Ham");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D6)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Pineapple");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D7)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Mixed Peppers");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D8)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Jalapeño");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D9)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Extra Cheese");
                                ExtraLoopNavigation();
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("\n Incorrect Input, Try Again...");
                                Console.ReadKey(true);
                            }
                        }

                    }

                    else if (userInput.Key == ConsoleKey.N)
                    {
                        loop = false;
                    }

                    else
                    {
                        Console.WriteLine("\n\n Incorrect Input, Try Again...");
                        Console.ReadKey(true);
                    }
                }

            } while (loop);
        }
        public static void CustomToppings()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Extras\n ------");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                for (int i = 0; i < 7; i++)
                        {
                            DateTimeMenu();
                            Console.WriteLine("\n Add Additional Toppings (Maximum of Seven)\n ------------------------------------------\n\n - NOTE: Each topping is £1.50 -\n\n Press ESC to Stop Adding Extra Toppings\n\n 1. Sausage\n 2. Bacon\n 3. Mushroom\n 4. Egg\n 5. Ham\n 6. Pineapple\n 7. Mixed Peppers\n 8. Jalapeño\n 9. Extra Cheese");
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                            ConsoleKeyInfo toppingInfo = Console.ReadKey(true);

                            if (toppingInfo.Key == ConsoleKey.Escape)
                            {
                                break;
                            }

                            if (toppingInfo.Key == ConsoleKey.D1)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Sausage");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D2)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Bacon");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D3)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Mushroom");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D4)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Egg");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D5)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Ham");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D6)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Pineapple");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D7)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Mixed Peppers");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D8)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Jalapeño");
                                ExtraLoopNavigation();
                                loop = false;
                            }

                            else if (toppingInfo.Key == ConsoleKey.D9)
                            {
                                PizzaCost += 1.5m;
                                ExtraTopping.Add("Extra Cheese");
                                ExtraLoopNavigation();
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("\n Incorrect Input, Try Again...");
                                Console.ReadKey(true);
                            }
                        }
            } while (loop);
        } 
        public static void Sides()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Extras\n ------");
                Console.Write("\n Add a Side Order? Y/N: ");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    DateTimeMenu();
                    Console.WriteLine("\n Choose Side Order\n --------------\n\n Press ESC to Skip Adding a Side Order\n\n 1. Grandma's Meatballs - £2.50\n 2. Garlic Bread - £1.75\n 3. Mozarella Sticks - £2.00\n 4. x8 BBQ Chicken Wings - £3.00");
                    ConsoleKeyInfo starterInfo = Console.ReadKey(true);

                    if (starterInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    if (starterInfo.Key == ConsoleKey.D1)
                    {
                        PizzaCost += 2.50m;
                        StarterAdd = "Grandma's Meatballs";
                        Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                        loop = false;
                        Console.ReadKey(true);
                    }

                    else if (starterInfo.Key == ConsoleKey.D2)
                    {
                        PizzaCost += 1.75m;
                        StarterAdd = "Garlic Bread";
                        Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                        loop = false;
                        Console.ReadKey(true);
                    }

                    else if (starterInfo.Key == ConsoleKey.D3)
                    {
                        PizzaCost += 2.00m;
                        StarterAdd = "Mozarella Sticks";
                        Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                        loop = false;
                        Console.ReadKey(true);
                    }

                    else if (starterInfo.Key == ConsoleKey.D4)
                    {
                        PizzaCost += 3.00m;
                        StarterAdd = "x 8 BBQ Chicken Wings";
                        Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                        loop = false;
                        Console.ReadKey(true);

                    }
                    else
                    {
                        Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    }

                }
                else if (userInput.Key == ConsoleKey.N)
                {
                    loop = false;
                }

                else
                {
                    Console.WriteLine("\n\n Incorrect Input - Try Again...");
                    Console.ReadKey(true);
                }

            } while (loop);
        }
        public static void Drink()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Extras\n ------");
                Console.Write("\n Add a Drink? Y/N: ");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                {
                    if (userInput.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        DateTimeMenu();
                        Console.WriteLine("\n Choose Drink\n -----------\n\n Press ESC to Skip Adding a Drink\n\n 1. Pepsi 0.33L - £0.75\n 2. Coca-Cola 0.33L £0.75\n 3. Rubicon Mango 0.33L - £0.75\n 4. 7Up 0.33L - £0.75");
                        ConsoleKeyInfo drinkInfo = Console.ReadKey(true);

                        if (drinkInfo.Key == ConsoleKey.Escape)
                        {
                            break;
                        }

                        if (drinkInfo.Key == ConsoleKey.D1)
                        {
                            PizzaCost += 0.75m;
                            AddDrink = "Pepsi 0.33L";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (drinkInfo.Key == ConsoleKey.D2)
                        {
                            PizzaCost += 0.75m;
                            AddDrink = "Coca-Cola 0.33L";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C}  - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (drinkInfo.Key == ConsoleKey.D3)
                        {
                            PizzaCost += 0.75m;
                            AddDrink = "Rubicon Mango 0.33L";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C}  - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (drinkInfo.Key == ConsoleKey.D4)
                        {
                            PizzaCost += 0.75m;
                            AddDrink = "7Up 0.33L";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine("\n\n Incorrect Input - Try Again...");
                            Console.ReadKey(true);
                        }
                    }
                    else if (userInput.Key == ConsoleKey.N)
                    {
                        loop = false;
                    }

                    else
                    {
                        Console.WriteLine("\n\n Incorrect Input - Try Again...");
                        Console.ReadKey(true);
                    }

                }
            } while (loop);
        }
        public static void Dessert()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine("\n Extras\n ------");
                Console.Write("\n Add Dessert? Y/N: ");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                {
                    if (userInput.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        DateTimeMenu();
                        Console.WriteLine("\n Choose a Desert\n ---------------\n\n Press ESC to Skip Adding a Dessert\n\n 1. Apple Pie - £1.50\n 2. Hot Fudge Cake - 1.75\n 3. 2 Scoops of Neopolitan Ice Cream - £1.00\n 4. Grandma's Tiramisu - £2.50");
                        ConsoleKeyInfo dessertInfo = Console.ReadKey(true);

                        if (dessertInfo.Key == ConsoleKey.Escape)
                        {
                            break;
                        }

                        if (dessertInfo.Key == ConsoleKey.D1)
                        {
                            PizzaCost += 1.5m;
                            AddDesert = "Apple Pie";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (dessertInfo.Key == ConsoleKey.D2)
                        {
                            PizzaCost += 1.75m;
                            AddDesert = "Hot Fudge Cake";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (dessertInfo.Key == ConsoleKey.D3)
                        {
                            PizzaCost += 1.00m;
                            AddDesert = "2 Scoops of Neopolitan Ice Cream";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C}  - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }

                        else if (dessertInfo.Key == ConsoleKey.D4)
                        {
                            PizzaCost += 2.50m;
                            AddDesert = "Grandma's Tiramisu";
                            Console.WriteLine("\n\n\n Current Bill Total: {0:C} - Press Enter to Proceed...", PizzaCost);
                            loop = false;
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine("\n\n Incorrect Input - Try Again...");
                            Console.ReadKey(true);
                        }

                        PaymentDetails();
                    }


                    else if (userInput.Key == ConsoleKey.N)
                    {
                        PaymentDetails();
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("\n\n Incorrect Input - Try Again...");
                        Console.ReadKey(true);
                    }

                }
            } while (loop);
        }
        public static void ExtraLoopNavigation()
        {
            Console.WriteLine("\n\n Topping Added - Press Enter To Add Another...");
            Console.ReadKey(true);
            Console.Clear();
        }
        public static void PaymentDetails()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine(" Choose Payment Method\n ---------------------\n\n - Additional £1.50 Delivery Charge on Orders Under £19.99 -\n\n 1. Cash on Delivery\n 2. Card Payment\n 3. Return to Main Menu");
                Console.WriteLine("\n\n\n Current Bill Total: {0:C}", PizzaCost);
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.D1)
                {
                    if (PizzaCost >= 20m)
                    {
                        CashPaymentOption();
                        loop = false;
                    }

                    else if (PizzaCost <= 19.99m)
                    {
                        PizzaCost += 1.50m;
                        CashPaymentOption();
                        loop = false;
                    }
                }

                else if (userInput.Key == ConsoleKey.D2)
                {
                    if (PizzaCost >= 20m)
                    {
                        CardPaymentOption();
                        loop = false;
                    }

                    else if (PizzaCost <= 19.99m)
                    {
                        PizzaCost += 1.50m;
                        CardPaymentOption();
                        loop = false;
                    }
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    Console.Write("\n Are You Sure? - Y/N: ");
                    ConsoleKeyInfo userChoice = Console.ReadKey(true);


                    if (userChoice.Key == ConsoleKey.Y)
                    {
                        MainMenu();
                    }

                    else if (userChoice.Key == ConsoleKey.N)
                    {
                    }

                    else
                    {
                        Console.WriteLine("\n\n Incorrect Input - Try Again...");
                        Console.ReadKey(true);
                    }
                }

            } while (loop);
        }
        public static void CashPaymentOption()
        {
            Console.Clear();
            DateTimeMenu();
            Console.WriteLine(" Final Bill Total: {0:C}", PizzaCost);
            Console.Write("\n\n Use Existing Customer Information? - Y/N: ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.ReadKey();

            if (userInput.Key == ConsoleKey.Y)
            {
                const string fileName = "Address.txt";
                if (File.Exists(fileName))
                {
                    Console.WriteLine("\n\n Press Enter to Proceed to Order Info Screen...");
                    Console.ReadKey(true);
                    Console.Clear();
                    WriteRecieptToFile();
                }
                else
                {
                    Console.WriteLine("\n\n No Address on File - Press Enter to Create One... ");
                    Console.ReadKey(true);
                    Console.Clear();
                    DateTimeMenu();
                    Console.Write(" Create Customer\n ---------------\n\n Enter Customer First Name: ");
                    String customerFirstName = Console.ReadLine();
                    CustomerFirstName = customerFirstName;

                    Console.Write("\n Enter Customer Last Name: ");
                    String customerLastName = Console.ReadLine();
                    CustomerLastName = customerLastName;

                    Console.Write("\n Enter First Line of Address: ");
                    String firstLineOfAddress = Console.ReadLine();
                    FirstLineOfAddress = firstLineOfAddress;

                    Console.Write("\n Enter Postcode: ");
                    String postcode = Console.ReadLine();
                    Postcode = postcode;

                    Console.Write("\n Enter Contact Number: ");
                    String contactNumber = Console.ReadLine();
                    ContactNumber = contactNumber;

                    Console.Write("\n Enter Prefered Delivery Time: ");
                    String deliveryPreference = Console.ReadLine();
                    DeliveryPreference = deliveryPreference;
                    Console.Clear();
                    WriteRecieptToFile();
                }
            }

            else if (userInput.Key == ConsoleKey.N)
            {
                const string fileName = "Address.txt";
                if (File.Exists(fileName))
                {
                    Console.WriteLine("\n\n Address Already on File - Press Enter to Use Existing Address");
                    Console.ReadKey(true);
                    Console.Clear();
                    WriteRecieptToFile();
                }

                else
                {
                    Console.WriteLine("\n\n Press Enter to Create New Customer... ");
                    Console.ReadKey(true);
                    Console.Clear();
                    DateTimeMenu();
                    Console.Write(" Create Customer\n ---------------\n\n Enter Customer First Name: ");
                    String customerFirstName = Console.ReadLine();
                    CustomerFirstName = customerFirstName;

                    Console.Write("\n Enter Customer Last Name: ");
                    String customerLastName = Console.ReadLine();
                    CustomerLastName = customerLastName;

                    Console.Write("\n Enter First Line of Address: ");
                    String firstLineOfAddress = Console.ReadLine();
                    FirstLineOfAddress = firstLineOfAddress;

                    Console.Write("\n Enter Postcode: ");
                    String postcode = Console.ReadLine();
                    Postcode = postcode;

                    Console.Write("\n Enter Contact Number: ");
                    String contactNumber = Console.ReadLine();
                    ContactNumber = contactNumber;

                    Console.Write("\n Enter Prefered Delivery Time: ");
                    String deliveryPreference = Console.ReadLine();
                    DeliveryPreference = deliveryPreference;
                    Console.Clear();
                    WriteRecieptToFile();
                }
            }
            else
            {
                Console.WriteLine("\n\n Incorrect Input - Try Again...");
                Console.ReadKey(true);
            }
        }
        public static void CardPaymentOption()
        {
            Console.Clear();
            DateTimeMenu();
            Console.WriteLine(" Final Bill Total: {0:C}", PizzaCost);
            Console.Write("\n\n Take Card Details\n -----------------\n\n Enter Name on Card: ");
            String cardName = Console.ReadLine();
            CardName = cardName;

            Console.Write("\n Enter Card Number: ");
            String cardNumber = Console.ReadLine();
            CardNumber = cardNumber;

            Console.Write("\n Enter Sort Code: ");
            String sortCode = Console.ReadLine();
            SortCode = sortCode;

            Console.Write("\n Enter Expiry Date: ");
            String expiryDate = Console.ReadLine();
            ExpiryDate = expiryDate;

            Console.Write("\n Enter Three Digit Security Number: ");
            ConsoleKeyInfo securityNumberEncryption = Console.ReadKey(true);
            while (securityNumberEncryption.Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                securityNumberEncryption = Console.ReadKey(true);
            }

            Console.Write("\n\n Keep Card Details - Y/N?: ");
            ConsoleKeyInfo cardInput = Console.ReadKey();
            Console.ReadKey();

            if (cardInput.Key == ConsoleKey.Y)
            {
                StreamWriter customerCardDetails = new StreamWriter("Customer Card Details.txt");
                customerCardDetails.WriteLine(
                    "\r\n\t\t\t   -|- Pizza Pizzaz -|-\r\n\r\n\r\n Date and Time of Card Details Storage: {0:f}\r\n\r\n\r\n Customer Card Details\r\n ---------------------\r\n\r\n Customer Name: {1} {2}\r\n Name on Card: {3}\r\n Card Number: {4}\r\n Sort Code: {5}\r\n Expiry Date: {6}", DateTime.Now, CustomerFirstName, CustomerLastName, CardName, CardNumber, SortCode, ExpiryDate);
                customerCardDetails.Close();
                Console.WriteLine("\n\n Press Enter to Proceed to Customer Details Screen...");
                Console.ReadKey(true);
                Console.Clear();
                CashPaymentOption();
            }

            else if (cardInput.Key == ConsoleKey.N)
            {
                Console.WriteLine("\n\n Press Enter to Proceed to Customer Details Screen...");
                Console.ReadKey(true);
                Console.Clear();
                CashPaymentOption();
            }

            else
            {
                Console.WriteLine("\n\n Incorrect Input - Try Again...");
                Console.ReadKey(true);
            }
        }
        public static void WriteRecieptToFile()
        {
            if (PizzaChoice != null)
            {
                StreamWriter writeToFile = new StreamWriter("Receipt.txt", true);
                writeToFile.WriteLine("\r\n Pizza Size: {0}\r\n Pizza Choice: {1}\r\n Crust: {2}\r\n Base Type: {3}\r\n Base Sauce: {4}\r\n\r\n Side Order: {5}\r\n Drink: {6}\r\n Dessert: {7}\r\n\r\n Total Cost: {8:C}", PizzaSize, PizzaChoice, CrustType, BaseType, BaseSauceChoice, StarterAdd, AddDrink, AddDesert, PizzaCost);
                writeToFile.Close();
            }

            if (PizzaChoice == null)
            {
                StreamWriter writeToFile = new StreamWriter("Receipt.txt", true);
                writeToFile.WriteLine("\r\n Pizza Size: {0}\r\n Crust: {1}\r\n Base Type: {2}\r\n Base Sauce: {3}\r\n\r\n Side Order: {4}\r\n Drink: {5}\r\n Dessert: {6}\r\n\r\n Total Cost: {7:C}", PizzaSize, CrustType, BaseType, BaseSauceChoice, StarterAdd, AddDrink, AddDesert, PizzaCost);
                writeToFile.Close();
            }
            WriteAddressToFile();
            WriteExtrasToFile();
            Console.WriteLine("\n\t\t\t   -|- PizzaPizzaz -|-\n");
            ReadAddressFromFile();
            ReadExtrasFromFile();
            ReadReceiptFromFile();
            Console.WriteLine("\n Press Enter to Finish...");
            Console.ReadKey(true);
        }
        public static void OrderStatus()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                DateTimeMenu();
                Console.WriteLine(" Update Pizza Delivery Status\n ----------------------------\n\n 1. Check Delivery Details/Delivery Status\n 2. Update to in Preperation\n 3. Update to Baking\n 4. Update to Out For Delivery\n 5. Update to Delivered\n 6. Return to Main Menu");
                Console.WriteLine("\n NOTE - Don't Update Status Until All Items in the Order Have Been Added"); 
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    const string fileName = "Receipt.txt";
                    if (File.Exists(fileName))
                    {
                        Console.WriteLine("\t\t\t   -|- PizzaPizzaz -|-");
                        ReadAddressFromFile();
                        ReadExtrasFromFile();
                        ReadReceiptFromFile();

                        if (DeliveryStatus != null)
                        {
                            Console.WriteLine("\n Current Delivery Status: {0}", DeliveryStatus);
                            Console.ReadKey(true);
                        }
                        else if (DeliveryStatus == null)
                        {
                            string none = "Awaiting an Update...";
                            Console.WriteLine("\n Current Delivery Status: {0}", none); 
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        DateTimeMenu();
                        Console.WriteLine(" Update Pizza Delivery Status\n ----------------------------\n\n 1. Check Delivery Details/Delivery Status\n 2. Update to in Preperation\n 3. Update to Baking\n 4. Update to Out For Delivery\n 5. Update to Delivered\n 6. Return to Main Menu");
                        Console.WriteLine("\n NOTE - Don't Update Status Until All Items in the Order Have Been Added");
                        Console.WriteLine("\n No Order on File - Press Enter to Go Back...");
                        Console.ReadKey(true);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    const string fileName = "Receipt.txt";
                    if (File.Exists(fileName))
                    {
                        DeliveryStatus = "Order Being Prepared";
                        Console.WriteLine("\n\n Status Updated to - Preperation Stage");
                    }
                    else
                    {
                        Console.WriteLine("\n\n No Order on File - Cannot Update Order Status...");
                    }
                    Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.D3)
                {
                    const string fileName = "Receipt.txt";
                    if (File.Exists(fileName))
                    {
                        DeliveryStatus = "Order Currently Baking";
                        Console.WriteLine("\n\n Status Updated to - Baking Stage");
                    }
                    else
                    {
                        Console.WriteLine("\n\n No Order on File - Cannot Update Order Status...");
                    }

                    Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.D4)
                {
                    const string fileName = "Receipt.txt";
                    if (File.Exists(fileName))
                    {
                        DeliveryStatus = "Order Out For Delivery";
                        Console.WriteLine("\n\n Status Updated to - Out For Delivery Stage");
                    }
                    else
                    {
                        Console.WriteLine("\n\n No Order on File - Cannot Update Order Status...");
                    }
                    Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.D5)
                {
                    const string fileName = "Receipt.txt";
                    if (File.Exists(fileName))
                    {
                        DeliveryStatus = "Order Delivered";
                        Console.WriteLine("\n\n Status Updated to - Delivered Stage");
                    }
                    else
                    {
                        Console.WriteLine("\n\n No Order on File - Cannot Update Order Status...");
                    }
                    Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.D6)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("\n Incorrect Input - Try Again");
                    Console.ReadKey(true);
                }

            } while (loop); 
        }
        public static void PizzaCostInformation()
        {
            AdminLogin();
            bool loop = true;
            do
            {
                PizzaProductionCost = 0;
                decimal totalProdutionCost = 31.75m;
                GrossProfit = 0 + PizzaCost;   

                if (GrossProfit > 0)
                {
                    Console.Clear();
                    DateTimeMenu();
                    Console.WriteLine(" Pizza Production Cost Details\n -----------------------------\n\n 1. Base Cost Details\n 2. Base Sauce Cost Details\n 3. Toppings Cost Details");
                    Console.WriteLine("\n\n Daily Total Pizza Production Cost: {0:C}", totalProdutionCost);
                    Console.CursorLeft = 102;
                    Console.CursorTop = 0;
                    Console.WriteLine(" Logged in: {0}", AdminUsername);
                    Console.CursorLeft = 0;
                    Console.CursorTop = 15;
                    Console.WriteLine("\n\n Takings for Current Order = {0:C} - Press Enter to Return to Main Menu...", GrossProfit);
                    StreamWriter writeToFile = new StreamWriter("Profit Information.txt", true); 
                    writeToFile.WriteLine("Money Made From Order: {0:C}\n", GrossProfit);  
                    writeToFile.Close();
                    ConsoleKeyInfo userEntry = Console.ReadKey(true);
                    if (userEntry.Key == ConsoleKey.Enter)
                    {
                        MainMenu();
                    }

                }

                else if (GrossProfit == 0) 
                    {
                    Console.Clear();
                    DateTimeMenu();
                    Console.WriteLine(" Pizza Production Cost Details\n -----------------------------\n\n 1. Base Cost Details\n 2. Base Sauce Cost Details\n 3. Toppings Cost Details\n 4. Return to Main Menu");
                    Console.CursorLeft = 102;
                    Console.CursorTop = 0;
                    Console.WriteLine(" Logged in: {0}", AdminUsername);
                    Console.CursorLeft = 0;
                    Console.CursorTop = 15;
                    Console.WriteLine("\n\n Daily Total Pizza Production Cost: {0:C}", totalProdutionCost);
                }

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    DateTimeMenu();
                    Console.CursorLeft = 102;
                    Console.CursorTop = 0;
                    Console.WriteLine(" Logged in: {0}", AdminUsername);
                    Console.CursorLeft = 0;
                    Console.CursorTop = 7;
                    Console.WriteLine(" Base Cost Details\n -----------------");
                    Console.WriteLine("\n - Flour 1kg - £1.00");
                    Console.WriteLine(" - 6 Eggs - £1.00");
                    Console.WriteLine(" - Milk 1 Pints - £0.75");
                    Console.WriteLine(" - Olive Oil 500ml - £3.50");
                    PizzaProductionCost += 1.00m;
                    PizzaProductionCost += 1.00m;
                    PizzaProductionCost += 0.75m;
                    PizzaProductionCost += 3.50m;
                    Console.WriteLine("\n\n Total Base Price: {0:C}", PizzaProductionCost);
                    Console.WriteLine("\n Press Enter to go Back...");
                    Console.ReadKey(true);
                }   

                else if (userInput.Key == ConsoleKey.D2)
                {
                    bool loop2 = true;
                    do
                    {
                        Console.Clear();
                        DateTimeMenu();
                        Console.CursorLeft = 102;
                        Console.CursorTop = 0;
                        Console.WriteLine(" Logged in: {0}", AdminUsername);
                        Console.CursorLeft = 0;
                        Console.CursorTop = 7;
                        PizzaProductionCost = 0;
                        Console.WriteLine(" Base Sauce Cost Details\n -----------------------\n 1. Basic Base Sauce\n 2. BBQ Base Sauce\n 3. Sundried Tomato, Garlic and Herb Sauce\n 4. Return to Previous Menu");
                        ConsoleKeyInfo userChoice = Console.ReadKey(true);

                        if (userChoice.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            DateTimeMenu();
                            Console.CursorLeft = 102;
                            Console.CursorTop = 0;
                            Console.WriteLine(" Logged in: {0}", AdminUsername);
                            Console.CursorLeft = 0;
                            Console.CursorTop = 7;
                            PizzaProductionCost = 0;
                            Console.WriteLine(" Marinara Sauce Cost Details\n ---------------------------");
                            Console.WriteLine("\n - Tomato Puree - £0.75");
                            Console.WriteLine(" - Mixed Herbs - £0.75");
                            Console.WriteLine(" - Mozarella Cheese 250g - £2.00");
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 2.00m;
                            Console.WriteLine("\n\n Total Marinara Sauce Price: {0:C}", PizzaProductionCost);
                            Console.WriteLine("\n Press Enter to go Back...");
                            Console.ReadKey(true);
                        }

                        else if (userChoice.Key == ConsoleKey.D2)
                        {
                            Console.Clear();
                            DateTimeMenu();
                            Console.CursorLeft = 102;
                            Console.CursorTop = 0;
                            Console.WriteLine(" Logged in: {0}", AdminUsername);
                            Console.CursorLeft = 0;
                            Console.CursorTop = 7;
                            PizzaProductionCost = 0;
                            Console.WriteLine(" BBQ Sauce Cost Details\n ----------------------");
                            Console.WriteLine("\n - Tomato Puree - £0.75");
                            Console.WriteLine(" - Brown Sugar - £1.50");
                            Console.WriteLine(" - Vinegar - £1.00");
                            Console.WriteLine(" - Honey - £1.00");
                            Console.WriteLine(" - Mixed Herbs - £0.75");
                            Console.WriteLine(" - Mozarella Cheese 250g - £2.00");
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 1.50m;
                            PizzaProductionCost += 1.00m;
                            PizzaProductionCost += 1.00m;
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 2.00m;
                            Console.WriteLine("\n\n Total BBQ Base Sauce Price: {0:C}", PizzaProductionCost);
                            Console.WriteLine("\n Press Enter to go Back...");
                            Console.ReadKey(true);
                        }

                        else if (userChoice.Key == ConsoleKey.D3)
                        {
                            Console.Clear();
                            DateTimeMenu();
                            Console.CursorLeft = 102;
                            Console.CursorTop = 0;
                            Console.WriteLine(" Logged in: {0}", AdminUsername);
                            Console.CursorLeft = 0;
                            Console.CursorTop = 7;
                            PizzaProductionCost = 0;
                            Console.WriteLine(" Sundried Tomato, Garlic and Herb Sauce Cost Details\n ---------------------------------------------------");
                            Console.WriteLine("\n - Sundried Tomato Puree - £1.75");
                            Console.WriteLine(" - Mixed Herbs - £0.75");
                            Console.WriteLine(" - Garlic - £0.75");
                            Console.WriteLine(" - Mozarella Cheese 250g - £2.00");
                            PizzaProductionCost += 1.75m;
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 0.75m;
                            PizzaProductionCost += 2.00m;
                            Console.WriteLine("\n\n Total Sundried Tomato, Garlic and Herb Sauce Price: {0:C}", PizzaProductionCost);
                            Console.WriteLine("\n Press Enter to go Back...");
                            Console.ReadKey(true);
                        }

                        else if (userChoice.Key == ConsoleKey.D4)
                        {
                            loop2 = false;
                        }
                    } while (loop2);
                }

                else if (userInput.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    DateTimeMenu();
                    Console.CursorLeft = 102;
                    Console.CursorTop = 0;
                    Console.WriteLine(" Logged in: {0}", AdminUsername);
                    Console.CursorLeft = 0;
                    Console.CursorTop = 7;
                    PizzaProductionCost = 0;
                    Console.WriteLine(" Topping Cost Details\n --------------------");
                    Console.WriteLine("\n - Sausages - £2.50");
                    Console.WriteLine(" - Mushrooms - £0.75");
                    Console.WriteLine(" - Paneer Cheese - £1.00");
                    Console.WriteLine(" - Pack of Ham - £1.25");
                    Console.WriteLine(" - Pineapple - £1.25");
                    Console.WriteLine(" - Mixed Peppers (Red, Green and Yellow) - £1.50");
                    Console.WriteLine(" - Jar of Jalapeños - £1.50");
                    PizzaProductionCost += 2.50m;
                    PizzaProductionCost += 0.75m;
                    PizzaProductionCost += 1.00m;
                    PizzaProductionCost += 1.25m;
                    PizzaProductionCost += 1.25m;
                    PizzaProductionCost += 1.50m;
                    PizzaProductionCost += 1.50m;
                    Console.WriteLine("\n\n Total Toppings Price: {0:C}", PizzaProductionCost);
                    Console.WriteLine("\n Press Enter to go Back...");
                    Console.ReadKey(true);
                }

                else if (userInput.Key == ConsoleKey.D4)
                {
                    loop = false;
                }

            } while (loop);
        }
        public static void AdminLogin()
        {
            // Login Inspired From - https://social.msdn.microsoft.com/Forums/vstudio/en-US/1cd66ce8-1f6d-4e92-854f-86dd32776259/how-can-i-encrypt-the-user-input?forum=csharpgeneral
            string systemPassword = "admin";
            bool systemLoop = true;
            do
            {
                Console.Write("\n Please Enter Administrator Userame: ");
                String usersName = Convert.ToString(Console.ReadLine());

                if (usersName == AdminUsername) 
                {
                    Console.Write("\n Please Enter Administrator Password: ");

                    string userPassword = "";

                    ConsoleKeyInfo info = Console.ReadKey(true);

                    while (info.Key != ConsoleKey.Enter)
                    {
                        Console.Write("*");

                        userPassword += info.KeyChar;

                        info = Console.ReadKey(true);
                    }

                    if (systemPassword == userPassword)
                    {
                        systemLoop = false;
                    }
                    else
                    {
                        Console.Write("\n\n Incorrect Password, Press Enter to Return...  ");
                        ConsoleKeyInfo userChoice = Console.ReadKey(true);

                        if (userChoice.Key == ConsoleKey.Enter)
                        {
                            MainMenu();
                        }

                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }

                else
                {
                    Console.Write("\n\n Incorrect Username, Press Enter to Return...  ");
                    ConsoleKeyInfo userChoice = Console.ReadKey(true);

                    if (userChoice.Key == ConsoleKey.Enter)
                    {
                        MainMenu();
                    }

                    Console.ReadKey(true);
                    Console.Clear();
                }

            } while (systemLoop);
        }
        public static void WriteExtrasToFile()
        {
            StreamWriter writeExtaInformationToFile = new StreamWriter("Extras.txt");
            writeExtaInformationToFile.WriteLine("\n Pizza Extras Added:");

            for (int i = 0; i < ExtraTopping.Count; i++)
            {
                int count = i + 1;
                writeExtaInformationToFile.WriteLine(" {0}. {1}", count, ExtraTopping[i]);
            }
            writeExtaInformationToFile.Close();
        }
        public static void WriteAddressToFile()
        {
            StreamWriter addressInformation = new StreamWriter("Address.txt");
            addressInformation.WriteLine("\r\n Date and Time of Order: {0:f} \r\n\r\n Customer Name {1} {2}\r\n Address: {3}\r\n Postcode {4}\r\n Contact Number: {5}\r\n Prefered Delivery Time: {6}", DateTime.Now, CustomerFirstName, CustomerLastName, FirstLineOfAddress, Postcode, ContactNumber, DeliveryPreference);
            addressInformation.Close();
        }
        public static void ReadAddressFromFile()
        {
            string[] readAddressFromFile = File.ReadAllLines("Address.txt");

            foreach (string line in readAddressFromFile)
            {
                Console.WriteLine(line);
            }
        }
        public static void ReadExtrasFromFile()
        {
            string[] readExtrasFromFile = File.ReadAllLines("Extras.txt");

            foreach (string line in readExtrasFromFile)
            {
                Console.WriteLine(line);
            }
        }
        public static void ReadReceiptFromFile()
        {
            string[] readFromFile = File.ReadAllLines("Receipt.txt");

            foreach (string line in readFromFile)
            {
                Console.WriteLine(line);
            }
        }
    }
}
