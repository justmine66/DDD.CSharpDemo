using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Domain_Model
{
    /// <summary>
    /// 完成收入确定策略类
    /// </summary>
    public class CompleteRecognitionStrategy : RecognitionStrategy
    {
        /// <summary>
        /// 计算确定收入额
        /// </summary>
        /// <param name="contract"></param>
        public override void CalculateRevenueRecognitions(Contract contract)
        {
            //直接入账
            contract.AddRevenueRecognition(new RevenueRecognition(contract.GetRevenue(), contract.GetWhenSigned()));
        }
    }
}
