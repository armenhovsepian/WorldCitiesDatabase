using ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertToCSV(DeserializeCountry(GetCountryFromSource()));
            Console.WriteLine("Hello World!");
        }


        static string GetCountryFromSource()
        {
            return File.ReadAllText("../../../Data/data.txt");
        }

        static IEnumerable<CountryByCity> DeserializeCountry(string fileCountry)
        {
            return JsonConvert.DeserializeObject<IEnumerable<CountryByCity>>(fileCountry);
        }


        static void ConvertToCSV(IEnumerable<CountryByCity> countries)
        {
            var sb = new StringBuilder();
            foreach (var country in countries)
            {
                foreach (var city in country.cities.Take(2))
                {
                    sb = sb.Append("(");
                    sb = sb.Append($"N'{country.name}'");
                    sb = sb.Append(",");
                    sb = sb.Append($"N'{country.shortname}'");
                    sb = sb.Append(",");
                    sb.Append($"N'{city.text}'");
                    sb = sb.Append("),");
                    sb.AppendLine();
                }


                sb.AppendLine();
            }

            var result = sb.ToString();

            File.WriteAllText("data.csv", result);

        }
    }
}
