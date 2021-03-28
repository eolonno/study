using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ЛР__2
{
    [Serializable]
    public class Account : IAccountClone
    {
        public Account()
        {

        }
        public Owner owner { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public bool SMSNotifications { get; set; }
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

        public Account Clone()
        {
            return (Account)this.MemberwiseClone();
        }
    }
}
