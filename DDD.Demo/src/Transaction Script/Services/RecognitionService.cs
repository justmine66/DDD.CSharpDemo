using DDD.Demo.src.Transaction_Script.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Transaction_Script.Services
{
    /// <summary>
    /// 收入确认服务
    /// </summary>
    public class RecognitionService
    {
        /// <summary>
        /// 查询某合同在指定日期前的已经确人的收入总额
        /// </summary>
        /// <param name="contractNumber">合同标识</param>
        /// <param name="asof">截止日期</param>
        public decimal? RecognizedRevenue(int contractNumber, DateTime asof)
        {
            try
            {
                return Gateway.Instance?.FindRecognitionsFor(contractNumber, asof)?.Sum(e => e.Amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 计算某合同的收入确认
        /// </summary>
        /// <param name="contractNumber">合同标识</param>
        public void CalculateRecognitions(int contractNumber)
        {
            try
            {
                IEnumerable<Contract> contracts = Gateway.Instance?.FindContractFor(contractNumber);
                if (null == contracts || contracts.Count() <= 0) return;
                var contract = contracts.ToList()[0];
                decimal totalRevenue = (decimal)contract?.Revenue;
                DateTime recognitionDate = (DateTime)contract?.DateSigned;

                string type = contract?.Product?.Type;
                if (type.Equals("S"))
                {
                    //采用电子表格软件入账
                    //规则：当天入账1/3；60天后再入账1/3；剩下的1/3，90天时入账。
                }
                else if (type.Equals("W"))
                {
                    //采用文字处理软件入账
                    //规则：立即入账。
                }
                else if (type.Equals("D"))
                {
                    //采用数据库软件入账
                    //规则：当天入账1/3；30天后再入账1/3；剩下的1/3，60天时入账。
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
