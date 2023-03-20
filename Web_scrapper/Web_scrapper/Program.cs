using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScrapper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request to weather.com
            String url = "https://weather.com/weather/today/l/312d1cff97dc06d1ad66303daaec1dc8546fedc870cc37199afaddacc042c51d";
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(url).Result;
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(html);

            // Get the temperature
            var temperatureElement = htmldocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature " + temperature);

            // Get the conditions
            var conditionElement = htmldocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine("Condition " + condition);

            // Get the location
            var cityElement = htmldocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var city = cityElement.InnerText.Trim();
            Console.WriteLine("City " + city);
        }
    }
}
