using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace SocketTest
{
    public class TelnetServer : AppServer<TelnetSession, StringRequestInfo>
    {
        public TelnetServer()
            : base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
        { }

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(TelnetSession session)
        {
            base.OnNewSessionConnected(session);
            TelnetSessionManager.SessionList.Add(session);
            //输出客户端IP地址  
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port + ":连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务已停止");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(TelnetSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            TelnetSessionManager.SessionList.Remove(session);
            
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port + ":断开连接");
        }
    }
}
