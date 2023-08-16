using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using System.Net.Http;


// sign in (or you don't have a account sign up) openweathermap.com
// get your api from there 

namespace Weather_Forecast
{
    internal class Data : Weather
    {

        string  api = "Write your api in here";
        
        // getting city name from our combobox
        private string city;
        public string City{ get => city; set => city = value; }

        // writed this to return multiple datas at same time
        private string willgive;
        public string Willgive { get => willgive; set => willgive = value; }
        public string Check()
        {   
            //setting the connection
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q={city}&mode=xml&lang=en&units=metric&appid={api}";

            //connecting it
            XDocument xml =  XDocument.Load(connection);

            // getting datas that we need
            var weather = xml.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var temp = xml.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var humidity = xml.Descendants("humidity").ElementAt(0).Attribute("value").Value;           
            var windspeed = xml.Descendants("speed").ElementAt(0).Attribute("value").Value;
            // sending datas to weather class
            var unit = ""; 
            if (willgive == "weather")
            {
                return weather;
            }
            if (willgive == "temperature")
            {
                return temp;
            }
            if (willgive == "humidity")
            {
                unit = xml.Descendants("humidity").ElementAt(0).Attribute("unit").Value;
                return  humidity + unit;
            }            
            if (willgive == "windspeed")
            {
                unit = xml.Descendants("speed").ElementAt(0).Attribute("unit").Value;
                return windspeed +  unit;
            }           
            return "";
        }        
    }
}
