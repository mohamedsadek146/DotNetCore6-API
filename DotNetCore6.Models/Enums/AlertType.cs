using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum AlertType
    {
        [DescriptionAnnotation("ALERT", "ALERT")]
        ALERT = 1,

        [DescriptionAnnotation("DANGER ", "DANGER")]
        DANGER= 2,

        [DescriptionAnnotation("NORMAL ", "NORMAL")]
        NORMAL = 3,

        [DescriptionAnnotation("SUCCESS ", "SUCCESS")]
        SUCCESS = 4,

    }
}
