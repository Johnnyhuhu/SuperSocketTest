﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase.Protocol;  

namespace SocketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start the server!");
            Console.ReadKey();
            Console.WriteLine();

            var bootstrap = BootstrapFactory.CreateBootstrap();

            try
            {
                if (!bootstrap.Initialize())
                {
                    Console.WriteLine("Failed to initialize!");
                    Console.ReadKey();
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            var result = bootstrap.Start();

            Console.WriteLine("Start result: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            //Stop the appServer
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();

        }
    }
}
