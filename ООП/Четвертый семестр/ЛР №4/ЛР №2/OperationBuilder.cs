using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР__2
{
    class OperationBuilder : IOpetaionBuilder<Operation>
    {
        Operation operation = new Operation("Создание счета", null, DateTime.Now);
        /// <summary>
        /// Добавление даты
        /// </summary>
        /// <param name="dt">Дата</param>
        public void AddDateTime(DateTime dt)
        {
            operation.Date = dt;
        }
        /// <summary>
        /// Добавление типа операции
        /// </summary>
        /// <param name="OperationType">Тип операции</param>
        public void AddOperationType(string OperationType)
        {
            operation.OperationType = OperationType;
        }
        /// <summary>
        /// Добавление суммы транзакции
        /// </summary>
        /// <param name="Total">Сумма транзакции</param>
        public void AddTotal(double Total)
        {
            operation.Total = Total;
        }
        /// <summary>
        /// Возвращает результат
        /// </summary>
        /// <returns>Операция</returns>
        public Operation GetResult()
        {
            return operation;
        }
    }
}
