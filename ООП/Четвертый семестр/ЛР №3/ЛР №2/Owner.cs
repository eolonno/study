using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ЛР__2
{
    [Serializable]
    public class Owner
    {
        public Owner()
        {

        }
        [RegularExpression(@"\w*", ErrorMessage = "Некорректные данные!")]
        public string FIO { get; set; }
        [Passport]
        public string Passport { get; set; }
        public DateTime BirthDate { get; set; }
        public Owner(string fio, string passport, DateTime birthDate)
        {
            FIO = fio;
            Passport = passport;
            BirthDate = birthDate;
        }
    }
}
