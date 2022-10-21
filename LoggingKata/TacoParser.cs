namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                
                logger.LogError("failed");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            var longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2
            var name = cells[2];
           
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            var location = new Point();
            location.Latitude = latitude;
            location.Longitude = longitude;
            tacoBell.Location= location;
            return tacoBell;
        }
    }
}