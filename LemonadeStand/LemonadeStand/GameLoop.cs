using System;
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
        public double allSales;
        public double profits;
        public int currentCrowd;
        public GameLoop()
        {
            currentDayNumber = 0;
            CreateWeekWeather();
            Player currentPlayer = new Player();
            while (currentDayNumber<7) {
                UserInterface forecastPrompt = new UserInterface();
                forecastPrompt.ForecastToday(forecastTemperatureListGame[currentDayNumber], forecastConditionsGame[currentDayNumber],currentDayNumber);
                currentPlayer.dailyExpenditure = 0;
                currentPlayer.BuyIngredient("Lemons", currentPlayer.currentFunds, currentPlayer.currentInventory);
                currentPlayer.BuyIngredient("Sugar Cubes", currentPlayer.currentFunds, currentPlayer.currentInventory);
                currentPlayer.BuyIngredient("Ice Cubes", currentPlayer.currentFunds, currentPlayer.currentInventory);
                currentPlayer.SetRecipe();
                currentPlayer.SetPitcherCount(currentPlayer.currentInventory, currentPlayer.currentRecipe);
                currentPlayer.SetPrice();
                double dailyExpenditure = currentPlayer.dailyExpenditure;
                Day newDay = new Day(currentDayNumber, actualTemperatureListGame[currentDayNumber], actualConditionsGame[currentDayNumber],currentPlayer.currentRecipe,currentPlayer.currentPrice,currentPlayer.pitcherCount);
                currentSales = newDay.salesToday;
                allSales += currentSales;
                currentPlayer.currentFunds += currentSales;
                currentCrowd = newDay.currentCrowd;
                UserInterface dayResultPrompt = new UserInterface();
                dayResultPrompt.resultsToday(actualTemperatureListGame[currentDayNumber], actualConditionsGame[currentDayNumber], currentCrowd,currentSales,dailyExpenditure);
                currentDayNumber += 1;
                if (currentDayNumber > 6)
                {
                    profits = currentPlayer.currentFunds;
                }
            }
            UserInterface weekResultPrompt = new UserInterface();
            weekResultPrompt.resultsWeek(allSales, profits);
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
