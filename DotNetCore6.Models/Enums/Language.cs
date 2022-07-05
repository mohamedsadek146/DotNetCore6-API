
using DotNetCore6.Models.Shared;

namespace DotNetCore6.Models.Enums
{
    public enum Language
    {
        [DescriptionAnnotation("عربى", "Arabic")]
        Arabic = 0,
        [DescriptionAnnotation("انجليزى", "English")]
        English = 1,
        [DescriptionAnnotation("عربى", "Frensh")]
        Frensh = 2,
        [DescriptionAnnotation("ألمانى", "German")]
        German = 3,
        [DescriptionAnnotation("أسبانى", "Spanish")]
        Spanish = 4,
    }
}
