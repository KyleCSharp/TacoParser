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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            string[] lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: done Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;
            double distance = 0;
            var corA = new GeoCoordinate();//put outside to save performace
            var corB = new GeoCoordinate();//outside to save performace
            // -done for me- Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED( means using loop in a loop) LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
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

            // done-Create a new corA Coordinate with your locA's lat and long

            // done-Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // done-Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            logger.LogInfo($"{tacobell1.Name} AND {tacobell2.Name} are the farthest apart.....from one another they are                 {distance/1609.344 } miles apart");
            //logger.LogInfo($"{distance/1609.344} miles apart  ");
        }
    }
}
