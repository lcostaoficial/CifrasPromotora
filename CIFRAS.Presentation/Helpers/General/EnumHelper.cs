using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CIFRAS.Presentation.Helpers.General
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
        }
    }
}