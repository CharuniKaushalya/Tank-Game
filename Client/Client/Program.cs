using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
     
    class Program
    {
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);
            try
            {
                sck.Connect(localEndPoint);
            }catch{
                Console.Write("Unable to connnect thhe remote end point\r\n");
            }
            Console.Write("Enter Text: ");
            string str = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(str);
            sck.Send(data);
            Console.Write("Data sent\r\n");
            Console.Write("Press any key to continue.........");
            Console.Read();
            sck.Close();

        }
    }
}


