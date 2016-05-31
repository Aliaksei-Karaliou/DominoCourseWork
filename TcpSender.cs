using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoCourseWork
{
    static class TcpSender
    {
        public static void Send(byte[] obj)
        {
            BinaryWriter writer = new BinaryWriter(Buffer.Client.GetStream());
            writer.Write(obj);
        }      
        public static void OnRead(IAsyncResult result)
        {
            try
            {
                int size = Buffer.Client.GetStream().EndRead(result);
                byte[] buffer = result.AsyncState as byte[];
                Array.Resize(ref buffer, size);
                if (buffer != null)
                    SelectHandler(buffer);
 
                // continue to read the next 64 bytes
                buffer = new byte[64];
                Buffer.Client.GetStream().BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SelectHandler(byte[] bytes)
        {
            switch (bytes[0])
            {
                case 0:
                    {
                        List<Domino> List = new List<Domino>();
                        for (int i = 1; i <= 24; i += 2)
                        {
                            Domino domino = new Domino(bytes[i], bytes[i+1]);
                            List.Add(domino);
                            if (i == 11)
                            {
                                Form1.Form.Invoke(new Action(() =>
                                {
                                    Form1.Form.CreatePlayer(0, List);
                                }));
                                List.Clear();
                            }
                        }
                        Form1.Form.Invoke(new Action(() =>
                        {
                            Form1.Form.CreatePlayer(1, List);
                            Form1.Form.NewRound();
                        }));
                        break;
                    }
                case 1:
                    {

                        break;
                    }
                default:
                    throw new NotSupportedException("unsupported handler");
            }
        }
    }
}
