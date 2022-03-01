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
    class Sydney
    {
        public static int population = 29_904;
    }
}

namespace USA
{
    class Miami
    {
        public static int population = 454_279;
    }
}

namespace Program
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine(Australia.Sydney.population > Canada.Sydney.population ? "Australian Sydney is bigger" : "Canadian Sydney is bigger");
            Console.WriteLine(USA.Miami.population > Canada.Sydney.population ? "Miami is bigger" : "Canadian Sydney is bigger");
            Console.WriteLine(USA.Miami.population > Australia.Sydney.population ? "Miami is bigger" : "Australian Sydney is bigger");
        }
    }
}