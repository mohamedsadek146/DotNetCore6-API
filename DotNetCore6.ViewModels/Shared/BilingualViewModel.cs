using DotNetCore6.Localization.Shared;
using DotNetCore6.ViewModels.Validators;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore6.ViewModels.Shared
{
    public class BilingualViewModel
    {

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "RequiredFiled")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "MaxLength")]
        [PreventHTMLValidator(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "SpecialCharactersNotAllowed")]
        public string NameArabic { set; get; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "RequiredFiled")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "MaxLength")]
        [PreventHTMLValidator(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "SpecialCharactersNotAllowed")]
        public string NameEnglish { set; get; }
    }
}
