using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.gateway
{
    /// <summary>
    /// 入口桩
    /// </summary>
    public class MessageGatewayStub : MessageGateway
    {
        protected override int doSend(string msgType, params object[] args)
        {
            int returnCode = this.IsMessageValid(msgType, args);
            if (returnCode == MessageSender.SUCCESS) this.messagesSent++;
            return returnCode;
        }

        private int IsMessageValid(string msgType,params object[] args)
        {
            if (this.shouldFailAllMessages) return -999;
            if (!LegalMsgTypes().Contains(msgType))
                return MessageSender.UNKNOWN_MESSAGE_TYPE;
            for (int i = 0; i < args.Length; i++)
            {
                object arg = args[i];
                if (null == arg) return MessageSender.NULL_PARAMETER;
            }
            return MessageSender.SUCCESS;
        }

        private bool shouldFailAllMessages = false;
        public void FailAllMessages()
        {
            shouldFailAllMessages = true;
        }

        private int messagesSent;
        public int GetNumberOfMsgSent()
        {
            return messagesSent;
        }

        public static ArrayList LegalMsgTypes()
        {
            ArrayList result = new ArrayList();
            result.Add(CONFIRM);
            return result;
        }
    }
}
