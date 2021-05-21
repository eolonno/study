using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Security.Cryptography;
using Dormitory.Models;

namespace Dormitory.Data
{
    public static class Validator
    {

        public static bool ValidateLogin(string str)
        {
            string symbols = "!@#$%^^&*()_+=-?.,<>:;\\\"'`~ ";
            if (str.Length < 4)
                throw new ValidatingException("Длина строки должна превышать 4 символа", ValidatingErrorTypes.StrError);
            foreach(var ch in str)
            {
                foreach(var symbol in symbols)
                {
                    if (ch == symbol)
                        throw new ValidatingException("Введены запрещенные символы", ValidatingErrorTypes.StrError);
                }
            }
            string HashedPassword = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str)));
            using(ApplicationContext db = new ApplicationContext())
            {
                var logins = DataWorker.GetAllUsers().Where(x => x.Login == str) as List<User>;
                if (logins != null)
                    throw new ValidatingException("Такой пользователь уже существует", ValidatingErrorTypes.StrError);
            }
            return true;
        }
        public static bool ValidatePassword(string password)
        {
            if (password.Length < 8)
                throw new ValidatingException("Длина пароля должна быть больше 8 символов", ValidatingErrorTypes.PassError);
            else if (password.Length > 16)
                throw new ValidatingException("Длина пароля не должна првевышать 16 символов", ValidatingErrorTypes.PassError);
            return true;
        }
    }
}
