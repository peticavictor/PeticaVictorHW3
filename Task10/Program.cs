using System;

namespace Australia 
{
    class Sydney
    {
        public static int population = 5_312_000;
    }
}

namespace Canada
{
    class Ottawa
    {
        public static int population = 994_837;
    }
}

namespace USA
{
    class WashingtonDC
    {
        public static int population = 692_683;
    }
}

namespace Program
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine(Australia.Sydney.population > Canada.Ottawa.population ? "Australian Sydney is bigger" : "Canadian Ottawa is bigger");
            Console.WriteLine(USA.WashingtonDC.population > Canada.Ottawa.population ? "Washington DC is bigger" : "Canadian Ottawa is bigger");
            Console.WriteLine(USA.WashingtonDC.population > Australia.Sydney.population ? "Washington DC is bigger" : "Australian Sydney is bigger");
        }
    }
}