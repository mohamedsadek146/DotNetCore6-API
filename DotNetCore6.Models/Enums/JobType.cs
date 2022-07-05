using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum JobType
    {
        [DescriptionAnnotation("ChangeTripRequestStatusToExpired", "ChangeTripRequestStatusToExpired")]
        ChangeTripRequestStatusToExpired = 0,

        [DescriptionAnnotation("ChangeTripRequestStatusToIgnored", "ChangeTripRequestStatusToIgnored")]
        ChangeTripRequestStatusToIgnored,

        [DescriptionAnnotation("AutoStartTrip", "AutoStartTrip")]
        AutoStartTrip,

        [DescriptionAnnotation("ChangeOrderStatusToReady", "ChangeOrderStatusToReady")]
        ChangeOrderStatusToReady,


    }
}
