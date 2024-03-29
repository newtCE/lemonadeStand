﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {   
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
            Random rng = new Random();
            for (int i = 0; i < 7; i++)
            {
                //Random rng = new Random(i); //this is an overload for deterministic rng
                int temperatureSelected = rng.Next(38, 104);
                rng.Next(i);
                actualTemperatureList.Add(temperatureSelected);
                forecastTemperatureList.Add(temperatureSelected + rng.Next(-16, 16));
                int conditionRangeHi = 4;
                if (temperatureSelected > 45)
                    {
                        conditionRangeHi = 3;
                    }
                if (temperatureSelected > 80)
                    {
                        conditionRangeHi = 2;
                    }
                int conditionSelected=rng.Next(0,conditionRangeHi);
                actualConditions.Add(conditionList[conditionSelected]);
                int forecastAccuracy = rng.Next(-1, 1)+conditionSelected;
                if (forecastAccuracy < 0)
                    {
                        forecastAccuracy = 0;
                    }
                else if (forecastAccuracy > 4)
                    {
                        forecastAccuracy = 4;
                    }
                forecastConditions.Add(conditionList[forecastAccuracy]);

            }
        }

        public string GenerateCondition(int inputNumber)
        {
            return conditionList[inputNumber];
        }

    }
}
