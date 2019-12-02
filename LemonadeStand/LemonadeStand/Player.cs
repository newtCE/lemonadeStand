using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {

        public List<int> currentRecipe = new List<int>() { 4, 4, 4 };
        public List<int> currentInventory = new List<int>() { 4, 4, 4 };
        public double currentFunds = 15;
        int pitcherCount = 0;
        double currentPrice;

        public void BuyIngredient(string ingredientType, double currentFunds, List<int> currentInventory)
        {
            bool purchasedIngredient = false;
            int purchasedAmount = 0;
            int ingredientIndex = 0;
            double ingredientCost = 100;
            switch (ingredientType)
            {
                case "Lemons":
                    ingredientIndex = 0;
                    ingredientCost = 1.00;
                    break;
                case "Sugar Cubes":
                    ingredientIndex = 1;
                    ingredientCost = .50;
                    break;
                case "Ice Cubes":
                    ingredientIndex = 2;
                    ingredientCost = .25;
                    break;
            }
            while (purchasedIngredient == false)
            {
                UserInterface purchaseUI = new UserInterface();
                purchasedAmount=purchaseUI.PurchaseIngredientPrompt(currentFunds,ingredientType, ingredientCost, currentInventory, ingredientIndex);
                if (currentFunds > (purchasedAmount * ingredientCost))
                {
                    this.currentInventory[ingredientIndex] += purchasedAmount;
                    this.currentFunds = currentFunds - (purchasedAmount * ingredientCost);
                    purchasedIngredient = true;
                }
                else
                {
                    purchaseUI.NotEnoughCash();                  
                }

            }
        }
        public void SetRecipe()
        {
            int lemonAmount;
            int sugarAmount;
            int iceAmount;
            UserInterface recipeUI = new UserInterface();
            lemonAmount=recipeUI.RecipePrompt(currentInventory, "Lemons");
            sugarAmount=recipeUI.RecipePrompt(currentInventory, "Sugar Cubes");
            iceAmount=recipeUI.RecipePrompt(currentInventory, "Ice Cubes");
            this.currentRecipe[0] +=lemonAmount;
            this.currentRecipe[1] += sugarAmount;
            this.currentRecipe[2] += iceAmount;
        }
        public void SetPitcherCount(List<int>currentInventory,List<int>currentRecipe)
        {
            int maxPitcher = 0;
            bool exertedSupply = false;
            while (exertedSupply == false)
            {
                currentInventory[0] = currentInventory[0] - currentRecipe[0];
                currentInventory[1] = currentInventory[1] - currentRecipe[1];
                currentInventory[2] = currentInventory[2] - currentRecipe[2];
                if (currentInventory[0]>-1 && currentInventory[1] >-1 && currentInventory[2] >-1)
                {
                    maxPitcher += 1;
                }
                else
                {
                    exertedSupply = true;
                }
            }
            UserInterface pitcherUI = new UserInterface();
            this.pitcherCount=pitcherUI.PitcherPrompt(currentInventory,currentRecipe,maxPitcher);
            this.currentInventory[0] = this.currentInventory[0] - (currentRecipe[0] * pitcherCount);
            this.currentInventory[1] = this.currentInventory[1] - (currentRecipe[1] * pitcherCount);
            this.currentInventory[2] = this.currentInventory[2] - (currentRecipe[2] * pitcherCount);
        }
        public void SetPrice()
        {
            UserInterface priceUI = new UserInterface();
            currentPrice = priceUI.PricePrompt();
        }
    }
    }
