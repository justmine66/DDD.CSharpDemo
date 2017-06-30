using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.gateway
{
    /// <summary>
    /// 存放网关的环境变量
    /// </summary>
    public class Environment
    {
        public static MessageGateway GetMsgGateway()
        {
            return new MessageGateway();
        }
    }
}
