using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    static class TcpSender
    {
        public static void Send(byte[] obj)
        {
            BinaryWriter writer = new BinaryWriter(Buffer.Client.GetStream());
            writer.Write(obj);
        }
        public static byte[] Read()
        {
            BinaryReader reader = new BinaryReader(Buffer.Client.GetStream());
            return reader.ReadBytes(2);
        }
    }
}
