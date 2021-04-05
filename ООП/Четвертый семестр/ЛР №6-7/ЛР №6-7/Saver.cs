using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace ЛР__6_7
{
    /// <summary>
    /// Класс для сохрания данных о жильцах в документ
    /// </summary>
    public static class Saver
    {
        /// <summary>
        /// Сохранение в документ
        /// </summary>
        /// <param name="tenants">Список для сохранения</param>
        public static void SaveList(List<Tenant> tenants)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Tenant>));
            using (FileStream fs = new FileStream("Tenants.xml", FileMode.Create))
            {
                xml.Serialize(fs, tenants);
            }
        }
        /// <summary>
        /// Чтение из документа
        /// </summary>
        /// <returns>Список элементов класса Tenant</returns>
        public static List<Tenant> ReadList()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Tenant>));
                using (FileStream fs = File.OpenRead("Tenants.xml"))
                {
                    return xml.Deserialize(fs) as List<Tenant>;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
