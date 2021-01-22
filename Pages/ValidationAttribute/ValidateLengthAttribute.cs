using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVC
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}'最短{1}，最长{2}.";
        //private int _minCharacters = Membership.Provider.MinRequiredPasswordLength;
        public int MinLenght { get; private set; }
        public int MaxLenght { get; private set; }
        public ValidateLengthAttribute()
            : base(_defaultErrorMessage)
        {
            MinLenght = 6;
            MaxLenght = 100;
        }
        public ValidateLengthAttribute(int minLenght)
            : base(_defaultErrorMessage)
        {
            MinLenght = minLenght;
            MaxLenght = 100;
        }
        public ValidateLengthAttribute(int minLenght, int maxLenght)
            : base(_defaultErrorMessage)
        {
            MinLenght = minLenght;
            MaxLenght = maxLenght;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, MinLenght, MaxLenght);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= MinLenght && valueAsString.Length < MaxLenght);
        }
    }
}
