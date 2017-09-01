using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTest.Client
{
    public class Start
    {
        private Socket clientSocket;

        List<byte> receivedData;

        string receivedContent;

        Encoding m_Encoding = Encoding.UTF8;

        private Socket CreateClientSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void ReConnection()
        {
            if (!clientSocket.Connected)
            {
                try
                {
                    clientSocket = CreateClientSocket();
                    clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("2013")));
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 重连服务器 " + "127.0.0.1" + ":" + "2013" + " 成功;\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 重连服务器 " + "127.0.0.1" + ":" + "2013" + " 失败，原因：" + e.Message + " ;\n");
                }
            }

        }

        private List<byte> ReceiveMessage(Socket socket, EndPoint serverAddress)
        {
            int length = 1024;
            byte[] buffer = new byte[length];
            int read = socket.ReceiveFrom(buffer, ref serverAddress);
            if (read < length)
                return buffer.Take(read).ToList();
            else
            {
                var total = buffer.ToList();
                total.AddRange(ReceiveMessage(socket, serverAddress));
                return total;
            }
        }

        public void send(string str)
        {
            //clientSocket.Send(m_Encoding.GetBytes(str + "\r\n"));
            clientSocket.Send(m_Encoding.GetBytes(str + "\r\n"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 发送消息：" + str + "\n");
        }

        public Start()
        {
            if (clientSocket == null)
            {
                clientSocket = CreateClientSocket();
            }

            this.ReConnection();
            Task.Factory.StartNew(() =>
            {
                while (clientSocket.Connected)
                {
                    if (clientSocket.Available > 0)
                    {
                        receivedData = ReceiveMessage(clientSocket, new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("2013")));
                        receivedContent = m_Encoding.GetString(receivedData.ToArray());
                        //this.Invoke(new Action(() =>
                        //{
                            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 收到服务器消息： " + receivedContent);
                        //}));
                    }
                    Thread.Sleep(100);
                }

            });


        }
    }
}
