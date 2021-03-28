using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace ЛР__2
{
    public class Adapter : IXMLAdapter
    {
        public string XMLToJSON(FileStream fs)
        {
            using (fs)
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Account>));
                List<Account> accs = new List<Account>();
                accs = xml.Deserialize(fs) as List<Account>;
                return JsonSerializer.Serialize(accs);
            }
        }
    }
}
