using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DominoCourseWork
{
    class XMLSerializer<T>
    {
        /*public T Read()
        {
            T result = default(T);
            using (FileStream fs = new FileStream(Console.in, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                result = (T)formatter.Deserialize(fs);
            }
            return result;
    }*/
        public string Write(T obj)
        {
           // try
            {
                using (FileStream fs = new FileStream("data0.dat", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, obj);
                }
            }
           /*catch
            {
                while (true) ;
            }*/
            string text = File.ReadAllText("data0.dat");
            return null;
        }

    }
}
