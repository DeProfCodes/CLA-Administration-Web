using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public static class EnumsHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()?.GetMember(value.ToString())?.First()?.GetCustomAttribute<DisplayAttribute>()?.Name ?? "NaN";
        }
    }
}
