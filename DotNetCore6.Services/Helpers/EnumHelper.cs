using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore6.Models.Enums;
using DotNetCore6.Models.Shared;

using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.Services.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(object obj, Language language = Language.Arabic)
        {
            return DescriptionAnnotation.GetDescription(obj, language);
        }
        public static List<SelectListItemViewModel> ToSelectableList<T>(Language language = Language.Arabic)
        {
            return
            (from item in Enum.GetValues(typeof(T)).Cast<T>().Select(x => x).ToList()
             select new SelectListItemViewModel
             {
                 ID = Convert.ToInt32(item),
                 Name = DescriptionAnnotation.GetDescription(item, language),
             }).ToList();
        }

        public static List<SelectListItemViewModel> ToSelectableList<T>(this IEnumerable<T> items)
        {
            return
            (from item in items
             select new SelectListItemViewModel
             {
                 ID = Convert.ToInt32(item),
                 Name = DescriptionAnnotation.GetDescription(item, Language.Arabic),
             }).ToList();
        }
    }
}
