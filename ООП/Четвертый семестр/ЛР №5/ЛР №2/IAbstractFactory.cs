using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР__2
{
    interface IAbstractFactory
    {
        /// <summary>
        /// Выполнение транзакции или создание счета
        /// </summary>
        /// <param name="OperationType">Тип операции</param>
        /// <param name="total">Сумма транзакции</param>
        /// <param name="Date">Дата и время транзакции (операции)</param>
        /// <returns></returns>
        Operation CreateOperation(string OperationType, double? total, DateTime? Date);
        /// <summary>
        /// Создание счета
        /// </summary>
        /// <param name="FIO">ФИО владельца</param>
        /// <param name="Passport">Паспортные данные (серия и номер)</param>
        /// <param name="dtp">Дата рождения</param>
        /// <param name="AccountTypeField">Тип счета</param>
        /// <param name="BalanceField">Начальный баланс</param>
        /// <param name="SMS">Получать оповещения по смс?</param>
        /// <param name="Banking">Подключать интернет-банкинг?</param>
        /// <returns></returns>
        Account CreateAccount(TextBox FIO, TextBox Passport, DateTimePicker dtp, ComboBox AccountTypeField, TextBox BalanceField, Panel SMS, Panel Banking);
    }
}
