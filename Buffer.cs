using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    static class Buffer
    {
        public static UsedDomino UsedDomino = new UsedDomino();
        public static TcpClient Client;
        public static TcpListener Listener;
    }
}
