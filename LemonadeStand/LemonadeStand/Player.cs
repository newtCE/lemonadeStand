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

        }
    }
    }
