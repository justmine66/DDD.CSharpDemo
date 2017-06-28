using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Domain_Model
{
    /// <summary>
    /// 合同类
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// 合同标识
        /// </summary>
        private long id;
        /// <summary>
        /// 产品
        /// </summary>
        private Product product;
        /// <summary>
        /// 收入确定总额
        /// </summary>
        private decimal revenue;
        /// <summary>
        /// 签订时间
        /// </summary>
        private DateTime whenSigned;
        /// <summary>
        /// 确定收入总额
        /// </summary>
        private ArrayList revenueRecognitions = new ArrayList();

        public Contract(Product product, decimal revenue, DateTime whenSigned)
        {
            this.product = product;
            this.revenue = revenue;
            this.whenSigned = whenSigned;
        }

        /// <summary>
        /// 查询在指定日期前已经确定的收入额
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns>收入总额</returns>
        public decimal RecognizedRevenue(DateTime date)
        {
            var result = this.revenue;
            foreach (var item in revenueRecognitions)
            {
                var r = (RevenueRecognition)item;
                if (r.IsRecognizableBy(date))
                    result = decimal.Add(result, r.GetAmount());
            }
            return result;
        }

        /// <summary>
        /// 计算收入确定额
        /// </summary>
        public void CalculateRecognitions()
        {
            product.CalculateRevenueRecognitions(this);
        }

        /// <summary>
        /// 添加收入确定额到合同
        /// </summary>
        /// <param name="revenueRecognition">收入确定类</param>
        public void AddRevenueRecognition(RevenueRecognition revenueRecognition)
        {
            revenueRecognitions.Add(revenueRecognition);
        }

        /// <summary>
        /// 获取收入确定额
        /// </summary>
        /// <returns></returns>
        public decimal GetRevenue()
        {
            return this.revenue;
        }

        /// <summary>
        /// 获取合同签订时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetWhenSigned()
        {
            return this.whenSigned;
        }
    }
}
