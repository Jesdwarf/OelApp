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
                new Drink {Name = "Beer", Units = 1.0},
                new Drink {Name = "StrongBeer", Units = 1.5},
                new Drink {Name = "FlaskeVodka", Units = 19}
            };
            JsonDAL.WriteToJsonFile(drinks);
        }
    }
}