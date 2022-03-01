using System;
using System.Collections.Generic;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating 7 Wonders objects
            GreatWall greatWall = new GreatWall( "Great Wall");
            ElCastillo elCastillo = new ElCastillo( "ElCastillo");
            Petra petra = new Petra( "Petra");
            MachuPicchu machuPicchu = new MachuPicchu( "MachuPicchu");
            ChristTheRedeemer christTheRedeemer = new ChristTheRedeemer( "Christ the Redeemer");
            Colosseum colosseum = new Colosseum( "Colosseum");
            TajMahal tajMahal = new TajMahal( "Taj Mahal");

            // add all wonders to a list
            List<Wonder> wonders = new List<Wonder>();

            wonders.Add(greatWall);
            wonders.Add(elCastillo);
            wonders.Add(petra);
            wonders.Add(machuPicchu);
            wonders.Add(christTheRedeemer);
            wonders.Add(colosseum);
            wonders.Add(tajMahal);

            // output all wonders
            foreach(Wonder wonder in wonders)
            {
                Console.WriteLine(wonder);
            }
        }
 
    }
}
