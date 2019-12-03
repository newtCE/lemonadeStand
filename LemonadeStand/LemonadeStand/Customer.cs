using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        double choiceCalculus;
        double budgetLevel;
        int sugarLevel;
        int lemonLevel;
        int iceLevel;
        int currentTemp;
        double currentPrice;
        public double amountPaid;
        Random seed = new Random();
        List<int> currentRecipe = new List<int>();

        public Customer(int currentTemp,List<int>currentRecipe,double currentPrice)
        {
            this.currentTemp = currentTemp;
            this.currentRecipe = currentRecipe;
            this.currentPrice = currentPrice;
            budgetLevel = 3 - .01 * (seed.Next(0, 75));
            SetLemonLevel();
            SetSugarLevel();
            SetIceLevel();
            JudgeProduct();

        }
        void SetLemonLevel()
        {
            lemonLevel = seed.Next(1, 10);
        }
        void SetSugarLevel()
        {
            sugarLevel = seed.Next(3, 11);
        }
        void SetIceLevel()
        {
            iceLevel = 1;
            if (currentTemp > 45)
            {
                iceLevel = 2;
            }
            if (currentTemp > 60)
            {
                iceLevel = 4;
            }
            if (currentTemp > 85)
            {
                iceLevel = 8;
            }
        }
        void JudgeProduct()
        {
            if (currentRecipe[0] > (sugarLevel - 3) && currentRecipe[0] < (sugarLevel + 3))
            {
                choiceCalculus += .33;
            }
            if (currentRecipe[1] > (lemonLevel - 3) && currentRecipe[1] < (lemonLevel + 3))
            {
                choiceCalculus += .33;
            }
            if (currentRecipe[2] > (iceLevel-3) && currentRecipe[2] < (iceLevel +3))
            {
                choiceCalculus += .33;
            }
            if (choiceCalculus >= .5)//meets at least 2 of the 3 preference criteria
            {
                if (currentPrice <= (budgetLevel * choiceCalculus))//price is at or below the maximum amount willing to spend x how much they want it
                {
                    amountPaid = currentPrice;
                }
            }
        }
    }
}
