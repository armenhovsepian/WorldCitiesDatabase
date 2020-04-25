using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class CountryByCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }

        public IEnumerable<city> cities { get; set; }
    }

    class city
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}
