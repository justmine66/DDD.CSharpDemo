using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Domain_Model
{
    /// <summary>
    /// 收入确定类
    /// </summary>
    public class RevenueRecognition
    {
        /// <summary>
        /// 金额
        /// </summary>
        private decimal amount;
        /// <summary>
        /// 日期
        /// </summary>
        private DateTime date;

        public RevenueRecognition(decimal amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }

        /// <summary>
        /// 获取金额
        /// </summary>
        /// <returns></returns>
        public decimal GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// 在某一给定日期之前是否有金额可被确定
        /// </summary>
        /// <param name="asof">日期</param>
        /// <returns>是否可确认</returns>
        public bool IsRecognizableBy(DateTime asof)
        {
            return asof >= this.date;
        }

    }
}
