using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public string currentDay;
        public int currentCrowd;
        public double currentCrowdDecimal;
        public int currentTemp;
        public int tempDifference;
        public string condition;
        public int idealTemp = 72;
        public int maxCrowd = 12;



        public int DetermineCurrentCrowd(int currentTemp, string condition, string currentDay)
        {
            currentCrowd = maxCrowd;
            currentCrowd = ConsiderDay(currentCrowd, currentDay);
            currentCrowd = ConsiderCondition(currentCrowd, condition);
            currentCrowd = ConsiderTemp(currentCrowd, currentTemp);
            if (currentCrowd < 1)
            {
                currentCrowd = 1;//give the player at least one customer on a given day just to be nice
            }
            return currentCrowd;
        }
        public int ConsiderDay(int currentCrowd, string currentDay)
        {
            switch (currentDay)
            {
                case "Tuesday":
                    currentCrowd = currentCrowd + 2;
                    break;

                case "Friday":
                    currentCrowd = currentCrowd + 3;
                    break;

                case "Saturday":
                case "Sunday":
                    currentCrowd = currentCrowd + 4;
                    break;
            }
            return currentCrowd;
        }
        public int ConsiderCondition(int currentCrowd, string condition)
        {
            currentCrowdDecimal = currentCrowd;
            switch (condition)
            {
                case "Sunny":
                    //no change
                    break;

                case "Cloudy":
                    currentCrowd = Convert.ToInt32(currentCrowdDecimal* .8);
                    break;

                case "Rainy":
                    currentCrowd = Convert.ToInt32(currentCrowdDecimal * .6);
                    break;

                case "Stormy":
                    currentCrowd = Convert.ToInt32(currentCrowdDecimal * .4);
                    break;

                case "Snowy":
                    currentCrowd = Convert.ToInt32(currentCrowdDecimal * .1);
                    break;
            }
            return currentCrowd;
        }
        public int ConsiderTemp(int currentCrowd,int temp)
        {
            currentCrowdDecimal = currentCrowd; //prepare a decimal for changes made due to temp
            tempDifference = currentTemp - idealTemp;
            if (tempDifference == 0)
            {
                return currentCrowd;    //no further modifying of crowd needed
            }
            else
            {
                if (tempDifference < 0)//it's cold remove percentage difference from crowd size
                {
                    currentCrowdDecimal = currentCrowdDecimal - (currentCrowdDecimal*((tempDifference * -1) / idealTemp));
                }
                else //it's hot add percentage difference from crowd size
                {
                    currentCrowdDecimal = currentCrowdDecimal + (currentCrowdDecimal * (tempDifference / idealTemp));
                }
            }
            currentCrowd = Convert.ToInt32(currentCrowdDecimal);
            return currentCrowd;
        }
    }
}
