using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DotNetCore6.ViewModels.Validators
{
    public class PreventHTMLValidator : ValidationAttribute
    {
        List<string> notAllowedWords = new List<string>() { ";", ">", "<", "alert", "script", };
        public override bool IsValid(object value)
        {
            string term = value.ToString().ToLower();
            bool containsBadWords = false;
            notAllowedWords.ForEach(word =>
            {
                if (term.Contains(word))
                    containsBadWords = true;
            });
            return !containsBadWords && Regex.IsMatch(term, @"^(?!.*<[^>]+>).*");
        }
    }
}
