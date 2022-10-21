using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;
using System.Reflection.Metadata.Ecma335;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
           

            logger.LogInfo("Log initialized");

            
            string[] lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

           
            var parser = new TacoParser();

            logger.LogInfo("Begin parsing");

            
            var locations = lines.Select(parser.Parse).ToArray();

           
            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;
            double distance = 0;
            var corA = new GeoCoordinate();//put outside to save performace
            var corB = new GeoCoordinate();//outside to save performace
           
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude= locA.Location.Longitude;


                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    corB.Latitude= locB.Location.Latitude;
                    corB.Longitude=locB.Location.Longitude;
                    if ( corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacobell1=locA;
                        tacobell2 = locB;
                    }







                }






            }

            
            logger.LogInfo($"{tacobell1.Name} AND {tacobell2.Name} are the farthest apart.....from one another they are                 {distance/1609.344 } miles apart");
            //logger.LogInfo($"{distance/1609.344} miles apart  ");
        }
    }
}
