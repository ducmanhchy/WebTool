using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebSampleTool2.App_Start.IdentityPolicy
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CustomEmailValidatorAttribute : ValidationAttribute
    {
        private const string RegexPattern = @"^[0-9a-zA-Z]+@[a-z]+(\.[a-z]+)+$";

        public CustomEmailValidatorAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }

        public bool IsValid(string value)
        {
            return new Regex(RegexPattern).IsMatch(value);
        }
    }
}