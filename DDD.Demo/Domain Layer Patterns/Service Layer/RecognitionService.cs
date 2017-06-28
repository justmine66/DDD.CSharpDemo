using DDD.Demo.Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Service_Layer
{
    /// <summary>
    /// 收入确认服务
    /// </summary>
    public class RecognitionService : ApplicationService
    {
        /// <summary>
        /// 计算某合同的收入确认额，并入账。
        /// </summary>
        /// <param name="contractNumber">合同标识</param>
        public void CalculateRecognitions(int contractNumber)
        {
            //真实情况下，必须进行原子化处理。
            Contract contract = Contract.ReadForUpdate(contractNumber);
            contract.CalculateRecognitions();
            //发送一个有关这一事件的电子邮件给指定的合同管理者
            this.GetEmailGateway().SendEmailMessage(
                contract.GetAdministratorEmailAddress(),
                $"RE:Contract #{contractNumber}",
                $"{contract.GetID()} has had revenue recognitions calcuted."
                );
            //通过消息中间件发布一个消息，以通知其他集成的应用程序。
            this.GetIntegrationGateway().PublishRevenueRecognitionCalculation(contract.GetID());
        }

        /// <summary>
        /// 查询某合同在指定日期前的已经确人的收入总额
        /// </summary>
        /// <param name="contractNumber">合同标识</param>
        /// <param name="asof">截止日期</param>
        public decimal? RecognizedRevenue(int contractNumber, DateTime asof)
        {
            return 0m;
        }
    }
}
