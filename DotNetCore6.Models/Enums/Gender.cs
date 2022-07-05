using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum Gender
    {
        [DescriptionAnnotation("ذكر", "Male")]
        MALE = 1,
        [DescriptionAnnotation("أنثي ", "Female")]
        FEMALE= 2,
        
    }
}
