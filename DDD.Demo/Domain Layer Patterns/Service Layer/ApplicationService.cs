using DDD.Demo.Service_Layer.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Service_Layer
{
    /// <summary>
    /// 应用服务--所有服务的层超类型
    /// </summary>
    public class ApplicationService
    {
        /// <summary>
        /// 电子邮件网关
        /// </summary>
        /// <returns></returns>
        protected IEmailGateway GetEmailGateway()
        {
            return null;
        }

        /// <summary>
        /// 集成网关
        /// </summary>
        /// <returns></returns>
        protected IIntegrationGateway GetIntegrationGateway()
        {
            return null;
        }
    }
}
