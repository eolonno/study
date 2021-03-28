using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР__2
{
    interface IOpetaionBuilder<T> where T : Operation
    {
        void AddOperationType(string OperationType);
        void AddTotal(double Total);
        void AddDateTime(DateTime dt);
        T GetResult();
    }
}
