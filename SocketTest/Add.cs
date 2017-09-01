using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest
{
    public class Add : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send("xxx", requestInfo.Body);
        }
    }
}
