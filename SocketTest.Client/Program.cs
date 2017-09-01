using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System.Net;

namespace SocketTest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new EasyClient();
            //// Initialize the client with the receive filter and request handler
            //client.Initialize(new FakeReceiveFilter(), (request) =>
            //{
            //    // handle the received request
            //    Console.WriteLine(request.Key);
            //});
            //fnConnect(client as EasyClient);

            Start __s = new Start();
            while (true)
            {
                string __str = Console.ReadLine();
                __s.send(__str);
            }
            
        }

        //private static async void fnConnect(EasyClient v_client)
        //{
            //// Connect to the server
            //var connected = await v_client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2013));
            //if (connected)
            //{
            //    // Send data to the server
            //    v_client.Send(Encoding.ASCII.GetBytes("LOGIN kerry"));
            //}


        //}
    }

    //public class MyReceiveFilter : TerminatorReceiveFilter<StringPackageInfo>
    //{
    //    public MyReceiveFilter()
    //        : base(Encoding.ASCII.GetBytes("||")) // two vertical bars as package terminator
    //    {
    //    }

    //    // other code you need implement according yoru protocol details
    //    public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
    //    {
    //        return null;
    //    }
    //}

    //public class FakeReceiveFilter : TerminatorReceiveFilter<StringPackageInfo>
    //{
    //    public FakeReceiveFilter()
    //        : base(new byte[] { 0x01, 0x02 })
    //    {

    //    }

    //    public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
    //    {
    //        return null;
    //    }
    //}


    
    
}
