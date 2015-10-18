using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace socket
{
    class Program
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static Socket sooock;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            sck.Listen(100);

            Socket accept = sck.Accept();
            Buffer = new byte[accept.SendBufferSize];
            int bytesRead = accept.Receive(Buffer);
            byte[] formatted = new byte[bytesRead];
            for(int i=0;i<bytesRead ;i++){
                formatted[i] = Buffer[i];
            }

            string strData = Encoding.ASCII.GetString(formatted);
            Console.Write(strData + "\r\n");
            Console.Read();
            sck.Close();
            accept.Close();


        }
    }
}
