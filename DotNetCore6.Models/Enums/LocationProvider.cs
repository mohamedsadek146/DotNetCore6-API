using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum LocationProvider
    {
        [DescriptionAnnotation("NON", "NON")]
        NON = 0,

        [DescriptionAnnotation("GPS", "GPS")]
        GPS = 1,

        [DescriptionAnnotation("NETWORK ", "NETWORK")]
        NETWORK = 2,
    }
}
