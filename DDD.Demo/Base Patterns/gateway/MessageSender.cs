using System;

namespace DDD.Demo.Base_Patterns.gateway
{
    internal class MessageSender
    {
        public static int NULL_PARAMETER = -1;//空参数
        public static int UNKNOWN_MESSAGE_TYPE = -2;//未知的消息类型
        public static int SUCCESS = 0;//代表确认信息

        internal int Send(string msg, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}