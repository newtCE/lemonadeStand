﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameLoop
    {
        public List<string> actualConditionsGame = new List<string>();
        public List<string> forecastConditionsGame = new List<string>();
        public List<int> actualTemperatureListGame = new List<int>();
        public List<int> forecastTemperatureListGame = new List<int>();
        public List<int> currentRecipe = new List<int>() {4,4,4};
        public int currentDayNumber;
        public double currentSales;
        public double currentPrice;
        public int currentCrowd;

        public GameLoop()
        {
            currentDayNumber = 0;
            CreateWeekWeather();
            currentPrice = 1.55;
            while (currentDayNumber<7) {
            Day newDay = new Day(currentDayNumber, actualTemperatureListGame[currentDayNumber], actualConditionsGame[currentDayNumber],currentRecipe,currentPrice);
                currentSales = newDay.salesToday;
                currentCrowd = newDay.currentCrowd;
            checkIf();
            currentDayNumber += 1;
            }
            
        }
        void checkIf()
        {
                Console.WriteLine("Day " + Convert.ToString(currentDayNumber+1) + " Weather " + actualConditionsGame[currentDayNumber] + " Forecast " + forecastConditionsGame[currentDayNumber] + " " + actualTemperatureListGame[currentDayNumber] + " " + forecastTemperatureListGame[currentDayNumber]+"\n Crowd: "+Convert.ToString(currentCrowd)+"\nSales: "+Convert.ToString(currentSales));
        }
        public void CreateWeekWeather()
        {
            Weather initialWeather = new Weather();
            initialWeather.GenerateWeather();
            actualConditionsGame = initialWeather.actualConditions;
            forecastConditionsGame = initialWeather.forecastConditions;
            actualTemperatureListGame = initialWeather.actualTemperatureList;
            forecastTemperatureListGame = initialWeather.forecastTemperatureList;
        }
    }
}
