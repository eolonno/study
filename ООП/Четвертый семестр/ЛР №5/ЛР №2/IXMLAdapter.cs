using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ЛР__2
{
    interface IXMLAdapter
    {
        
        string XMLToJSON(FileStream fileStream);
    }
}
