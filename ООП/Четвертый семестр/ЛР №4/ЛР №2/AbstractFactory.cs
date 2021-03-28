using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР__2
{
    public class AbstractFactory : IAbstractFactory
    {
        public Account CreateAccount(TextBox FIO, TextBox Passport, DateTimePicker dtp, ComboBox AccountTypeField, TextBox BalanceField, Panel SMS, Panel Banking)
        {
            return new Account(new Owner(FIO.Text, Passport.Text, dtp.Value),
                AccountTypeField.Text,
                Convert.ToDouble(BalanceField.Text.Length > 0 ? BalanceField.Text : "0"),
                Account.Toggle(SMS),
                Account.Toggle(Banking));
        }

        public Operation CreateOperation(string OperationType, double? total, DateTime? Date)
        {
            OperationBuilder operationBuilder = new OperationBuilder();
            if (total == null)
            {
                operationBuilder.AddDateTime(Date != null ? Convert.ToDateTime(Date) : DateTime.Now);
                return operationBuilder.GetResult();
            }
            else
            {
                operationBuilder.AddOperationType(OperationType);
                operationBuilder.AddTotal(Convert.ToDouble(total));
                return operationBuilder.GetResult();
            }

        }
    }
}
