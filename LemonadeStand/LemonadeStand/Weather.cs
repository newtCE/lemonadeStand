using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather:GameLoop
    {
        public string condition;
        public int temperature;
        public List<string> dayList = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        public List<string> conditionList = new List<string>() {"Sunny","Cloudy","Rainy", "Stormy", "Snowy"};
        public List<string> actualConditions = new List<string>();
        public List<string> forecastConditions = new List<string>();
        public List<int> actualTemperatureList = new List<int>();
        public List<int> forecastTemperatureList = new List<int>();

        public Weather()
        {

        }
        public void GenerateWeather()
        {
            for (int i = 0; i < 7; i++)
            {
                int temperatureSelected = SelectRandomInt(38, 104);
                actualTemperatureList.Add(temperatureSelected);
                int conditionRangeHi = 4;
                if (temperatureSelected > 45)
                {
                    conditionRangeHi = 3;
                }
                if (temperatureSelected > 80)
                {
                    conditionRangeHi = 2;
                }
                int conditionSelected=SelectRandomInt(0,conditionRangeHi);
                actualConditions.Add(conditionList[conditionSelected]);
            }
        }
        public void GenerateForecast()
        {
            for (int i = 0; i < 7; i++)
            {
                forecastTemperatureList[i] = actualTemperatureList[i]+SelectRandomInt(-8,8);
            }
        }
        public string GenerateCondition(int inputNumber)
        {
            return conditionList[inputNumber];
        }

        public string PassTodaysCondition(string currentCondition)
        {
            condition = "Snowy";
            return condition;
        }
        public int PassTodaysTemperature(int currentTemperature)
        {
            temperature = 155;
            return temperature;
        }

    }
}
