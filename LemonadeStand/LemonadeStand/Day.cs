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
        int maxCrowd = 12;
        int currentCrowd;


        public int DetermineCurrentCrowd(int temp, string condition, string currentDay)
        {
            currentCrowd = maxCrowd;
            currentCrowd = ConsiderDay(currentCrowd, currentDay);
            currentCrowd = ConsiderCondition(currentCrowd, condition);
            currentCrowd = ConsiderTemp(currentCrowd, temp);
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
            switch (condition)
            {
                case "Sunny":
                    //no change
                    break;

                case "Cloudy":
                    currentCrowd = currentCrowd* 2;
                    break;

                case "Rainy":
                    break;

                case "Stormy":
                    break;

                case "Snowy":
                    break;
            }
            return currentCrowd;
        }
        public int ConsiderTemp(int currentCrowd,int temp)
        {
            return currentCrowd;
        }
        }
    }
}
