using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DominoCourseWork
{
    [Serializable]
    public class SaveClass
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public List<Domino> Table { get; set; }
        public Point Point { get; set; }
        public SaveClass(Player Player1, Player Player2, List<Domino> Table, Point Point)
        {
            this.Player1 = Player1;
            this.Player2 = Player2;
            this.Point = Point;
            this.Table = new List<Domino>(Table);
        }
        public SaveClass()
        {

        }
        public void Save(string filename)
        {
            filename = "file.xml";
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(GetType());
                serializer.Serialize(stream, this);
            }
        }
        public static SaveClass Open(string filename)
        {

        }
    }
}
