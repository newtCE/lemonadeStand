using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        public UserInterface()
        {

        }
        public void ShoppingSession()
        {

        }
        public int PurchaseIngredientPrompt(double currentFunds,string ingredientType, double ingredientCost,List<int> currentInventory,int ingredientIndex)
        {
            bool purchasedIngredient = false;
            string inputToCheck;
            int purchasedAmount = 0;
            while (purchasedIngredient == false)
            {
                Console.WriteLine("You currently have $" + currentFunds);
                Console.WriteLine(ingredientType + " cost $" + Convert.ToString(ingredientCost) + " each\nYou have " + Convert.ToString(currentInventory[ingredientIndex]) + " " + ingredientType + "\nHow many would you like to buy?");
                inputToCheck = Console.ReadLine();
                if (Int32.TryParse(inputToCheck,out purchasedAmount))
                {
                    purchasedIngredient = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input, please input only whole numbers..."); ;
                }
            }
            return purchasedAmount;
        }
        public void NotEnoughCash()
        {
            Console.WriteLine("You do not have enough money to buy this amount...Please input a lesser amount...");
        }
        public int RecipePrompt(List<int> currentInventory,string ingredientType)
        {
            int ingredientCount=0;
            int ingredientIndex = 0;
            string inputToCheck;
            bool countChosen = false;
            switch (ingredientType)
            {
                case "Lemons":
                    ingredientIndex = 0;
                    break;
                case "Sugar Cubes":
                    ingredientIndex = 1;
                    break;
                case "Ice Cubes":
                    ingredientIndex = 2;
                    break;
            }
            while (countChosen == false) { 
                Console.WriteLine("You currently have\n" + currentInventory[0] + " lemons\n" + currentInventory[1] + " sugar cubes\n" + currentInventory[2] + " ice cubes");
                Console.WriteLine("How many "+ ingredientType+ " would you like to use per pitcher of lemonade?");
                inputToCheck = Console.ReadLine();
                if (Int32.TryParse(inputToCheck, out ingredientCount))
                {
                    if (ingredientCount < currentInventory[ingredientIndex])
                    {
                        countChosen = true;
                    }
                    else
                    {
                        Console.WriteLine("Not enough of this ingredient is available for this recipe...");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input, please input only whole numbers...");
                }
            }
            return ingredientCount;
        }
        public int PitcherPrompt(List<int> currentInventory,List<int>currentRecipe,int maxPitchers)
        {
            int pitcherCount = 0;
            while (pitcherCount == 0)
            {
                Console.WriteLine("A pitcher of lemonade will provide enough lemonade for 10 cups.");
                Console.WriteLine("Your inventory allows you to make " + maxPitchers + " of your current recipe.\nHow many pitchers will you make for today?");
            }
            return pitcherCount;
        }
        public double PricePrompt()
        {
            return 2;
        }
    }
}
