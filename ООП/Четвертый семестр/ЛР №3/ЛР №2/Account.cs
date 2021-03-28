using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ЛР__2
{
    [Serializable]
    public class Account
    {
        public Account()
        {

        }
        public Owner owner { get; set; }
        public string AccountType { get; set; }
        [Required(ErrorMessage = "Введите данные!")]
        public double Balance { get; set; }
        [Required(ErrorMessage = "Введите данные!")]
        public bool SMSNotifications { get; set; }
        [Required(ErrorMessage = "Введите данные!")]
        public bool InternetBanking { get; set; }
        public Account(Owner _Owner, string accountType, double balance, bool SMS, bool Banking)
        {
            owner = _Owner;
            AccountType = accountType;
            SMSNotifications = SMS;
            InternetBanking = Banking;
            Balance = balance;
        }
        static public bool Toggle(Panel toggle)
        {
            var RadioButton = (RadioButton)toggle.Controls[0];
            if (RadioButton.Checked && RadioButton.Text == "Нет")
                return false;
            else return true;
        }
    }
}
