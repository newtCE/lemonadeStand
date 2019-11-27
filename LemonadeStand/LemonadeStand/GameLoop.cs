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
        public int currentDayNumber;
        public GameLoop()
        {
            currentDayNumber = 0;
            CreateWeekWeather();
            Day newDay = new Day(currentDayNumber,actualTemperatureListGame[currentDayNumber],actualConditionsGame[currentDayNumber]);
            checkIf();
        }
        void checkIf()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Day " + Convert.ToString(i + 1) + " " + actualConditionsGame[i] + " " + forecastConditionsGame[i] + " " + actualTemperatureListGame[i] + " " + forecastTemperatureListGame[i]);
            }
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
