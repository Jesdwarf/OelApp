using System;
using System.Collections.Generic;

namespace OelApp
{
    public static class GenerateSampleData
    {
        public static void Generate()
        {
            List<Drink> drinks = new List<Drink>
            {
                new Drink {Id = 1, Name = "Øl", Units = 1.0},
                new Drink {Id = 2, Name = "Vild guldøl", Units = 1.5},
                new Drink {Id = 3, Name = "En kodyl flaske vodka", Units = 19}
            };
            JsonDAL.WriteToJsonFile(drinks);
        }
    }
}