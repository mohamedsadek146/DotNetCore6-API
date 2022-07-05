using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum NumOfDays
    {
        [DescriptionAnnotation("SEVEN_DAYS", "SEVEN_DAYS")]
        SEVEN_DAYS = 7,
        [DescriptionAnnotation("THIS_DAY ", "THIS_DAY")]
        THIS_DAY = 0,
        [DescriptionAnnotation("CURRENT_MONTH ", "CURRENT_MONTH")]
        CURRENT_MONTH = 1,
        [DescriptionAnnotation("THIRTY_DAYS ", "THIRTY_DAYS")]
        THIRTY_DAYS = 30,
        [DescriptionAnnotation("LAST_MONTH ", "LAST_MONTH")]
        LAST_MONTH = 2,
        [DescriptionAnnotation("QUARTER ", "QUARTER")]
        QUARTER =3,
    }
}
