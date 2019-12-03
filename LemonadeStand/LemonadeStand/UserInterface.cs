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
                    if (ingredientCount <= currentInventory[ingredientIndex])
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
            string inputToCheck;
            while (pitcherCount <1)
            {
                Console.WriteLine("A pitcher of lemonade will provide enough lemonade for 10 cups.");
                Console.WriteLine("Your inventory allows you to make " + maxPitchers + " of your current recipe.\nHow many pitchers will you make for today?");
                inputToCheck = Console.ReadLine();
                if (Int32.TryParse(inputToCheck, out pitcherCount))
                {
                    if (pitcherCount <= maxPitchers && pitcherCount>0)
                    {
                        //we are good
                    }
                    else
                    {
                        Console.WriteLine("Not enough ingredients available for that many pitchers...");
                        pitcherCount = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input, please input only whole numbers greater than 0...");
                }
            }
            return pitcherCount;
        }
        public double PricePrompt()
        {
            string inputToCheck;
            double determinedCost = 0;
            while (determinedCost <= 0)
            {
                Console.WriteLine("How much will you charge for a cup of lemonade?");
                inputToCheck = Console.ReadLine();
                if (double.TryParse(inputToCheck, out determinedCost))
                {
                    if (determinedCost>0)
                    {
                        //all good
                    }
                    else
                    {
                        Console.WriteLine("Cannot cost $0.00 or less...");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input, positive number value above 0.00...");
                }
            }
            return determinedCost;
        }
        public void SoldOutMessage()
        {
            Console.WriteLine("Customers have purchased all available lemonade! Time to close up shop for today!");

        }
        public void ForecastToday(int forecastTemp, string forecastCondition,int dayNumber)
        {
            string dayName = "Monday";
            switch (dayNumber)
            {
                case 0:
                    dayName = "Monday";
                break;
                case 1:
                    dayName = "Tuesday";
                    break;
                case 2:
                    dayName = "Wednesday";
                    break;
                case 3:
                    dayName = "Thursday";
                    break;
                case 4:
                    dayName = "Friday";
                    break;
                case 5:
                    dayName = "Saturday";
                    break;
                case 6:
                    dayName = "Sunday";
                    break;
            }
            Console.WriteLine("Day " + (dayNumber + 1) + ": " + dayName);
            Console.WriteLine("Today is expected to be " + forecastCondition + " and " + forecastTemp + " degrees. Let's consider that when thinking about our recipe and how much to make...");
            Console.ReadLine();
        }
        public void resultsToday(int actualTemp, string actualCondition, int crowdSize, double sales, double dailyExpenditure)
        {
            Console.WriteLine("Today it was " + actualCondition + " and " + actualTemp + " degrees");
            Console.WriteLine(crowdSize+" people passed by the lemonade stand which resulted in a total of $"+sales+" in sales.");
            if (sales - dailyExpenditure > 0)
            {
                Console.WriteLine("Today's expenditure was $" + dailyExpenditure + " resulting in a daily profit of $" + (sales - dailyExpenditure));
            }
            else
            {
                Console.WriteLine("Today's expenditure was $" + dailyExpenditure + " resulting in a loss of $" + (Math.Abs(sales - dailyExpenditure)));
            }
            Console.ReadLine();
        }
        public void resultsWeek(double totalSales, double currentCash)
        {
            Console.WriteLine("After a week of business you made $"+totalSales+" in sales with a 7 day profit of $"+currentCash+"\nThanks for playing!");
            Console.ReadLine();
        }
    }
}
