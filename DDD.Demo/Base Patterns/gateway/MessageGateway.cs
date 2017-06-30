using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.gateway
{
    /// <summary>
    /// 消息网关
    /// </summary>
    public class MessageGateway : IMessageGateway
    {
        protected static string CONFIRM = "CNFRM";//代表确认信息
        private MessageSender sender;

        public void SendConfirmation(string orderID, int amount, string symbol)
        {
            object[] args = new object[] { orderID, amount, symbol };
            this.send(CONFIRM, args);
        }

        private void send(string msg, params object[] args)
        {
            int returnCode = this.doSend(msg, args);
            if (returnCode == MessageSender.NULL_PARAMETER)
                throw new ArgumentNullException("Null Parameter passed for msg type" + msg);
            if (returnCode == MessageSender.UNKNOWN_MESSAGE_TYPE)
                throw new Exception("Unknown msg type");
        }

        protected virtual int doSend(string msg, params object[] args)
        {
            return sender.Send(msg, args);
        }
    }
}
