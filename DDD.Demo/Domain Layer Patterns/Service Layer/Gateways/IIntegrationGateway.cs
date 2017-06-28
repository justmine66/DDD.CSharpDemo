using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Service_Layer.Gateways
{
    /// <summary>
    /// 集成网关
    /// </summary>
    public interface IIntegrationGateway
    {
        void PublishRevenueRecognitionCalculation(int contract);
    }
}
