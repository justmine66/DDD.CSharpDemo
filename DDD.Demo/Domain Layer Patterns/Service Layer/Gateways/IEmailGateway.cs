using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Service_Layer.Gateways
{
    /// <summary>
    /// 电子邮件网关
    /// </summary>
    public interface IEmailGateway
    {
       void SendEmailMessage(string toAddress, string subject, string body);
    }
}
