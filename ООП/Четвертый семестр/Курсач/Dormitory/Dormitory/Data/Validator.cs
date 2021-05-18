using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dormitory.Data
{
    public static class Validator
    {
        public static bool ValidateString(string str)
        {
            string symbols = "!@#$%^^&*()_+=-?.,<>:;\\\"'`~";
            if (str.Length < 4)
                throw new Exception("Длина строки должна превышать 4 символа");
            foreach(var ch in str)
            {
                foreach(var symbol in symbols)
                {
                    if (ch == symbol)
                        throw new Exception("Введены запрещенные символы");
                }
            }
            return true;
        }
        public static bool ValidatePassword(string password)
        {
            // !!! RETURN TRUE !!!
            return true;
            if (password.Length < 8)
                throw new Exception("Длина пароля должна быть больше 8 символов");
            else if (password.Length > 16)
                throw new Exception("Длина пароля не должна првевышать 16 символов");
            return true;
        }
    }
}
