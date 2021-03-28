using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ЛР__2
{
    class PassportAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                
                string passport = value.ToString();
                if (Regex.IsMatch(passport, @"^\w{2}\d{7}$"))
                    return true;
                else
                    ErrorMessage = "Некорректно введенны данные!";
            }
            return false;
        }
    }
}
