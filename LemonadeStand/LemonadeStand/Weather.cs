using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
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

        public string PassTodaysCondition(string currentCondition)
        {
            return "Sunny";
        }
        public int PassTodaysTemperature(int currentCondition)
        {
            return 45;
        }

    }
}
