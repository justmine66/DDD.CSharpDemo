using DDD.Demo.Table_Module.ValueoObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Table_Module.Layer_SuperTypes
{
    /// <summary>
    /// 合同表
    /// </summary>
    public class Contract : TableModule
    {
        public Contract(DataSet ds) : base(ds, "Contracts")
        {

        }

        /// <summary>
        /// 根据给定的主键获取数据表中的特定行
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>行数据</returns>
        public DataRow this[int key]
        {
            get
            {
                string filter = $"ID={key}";
                return table.Select(filter)[0];
            }
        }

        /// <summary>
        /// 计算合同的收入确定额
        /// </summary>
        /// <param name="contractID">合同标识</param>
        public void CalculateRecognitions(int contractID)
        {
            DataRow contractRow = this[contractID];
            decimal amount = (decimal)contractRow["amont"];
            RevenueRecognition rr = new RevenueRecognition(table.DataSet);
            Product prod = new Product(table.DataSet);
            int prodID = this.GetProductId(contractID);
            if (prod.GetProductType(prodID) == ProductType.WP)
                rr.Insert(contractID, amount, this.GetWhenSigned(contractID));
            else if (prod.GetProductType(prodID) == ProductType.SS)
            {
                decimal[] allocation = this.Allocate(amount, 3);
                rr.Insert(contractID, allocation[0], this.GetWhenSigned(contractID));
                rr.Insert(contractID, allocation[1], this.GetWhenSigned(contractID).AddDays(60));
                rr.Insert(contractID, allocation[2], this.GetWhenSigned(contractID).AddDays(90));
            }
            else if (prod.GetProductType(prodID) == ProductType.DB)
            {
                decimal[] allocation = this.Allocate(amount, 3);
                rr.Insert(contractID, allocation[0], this.GetWhenSigned(contractID));
                rr.Insert(contractID, allocation[1], this.GetWhenSigned(contractID).AddDays(30));
                rr.Insert(contractID, allocation[2], this.GetWhenSigned(contractID).AddDays(60));
            }
        }

        private int GetProductId(int contractID)
        {
            return (int)this[contractID]["ProductID"];
        }

        private DateTime GetWhenSigned(int contractID)
        {
            return (DateTime)this[contractID]["WhenSigned"];
        }

        /// <summary>
        /// 按比例等比分配收入确定总额，并将全部结果装入数组返回。
        /// </summary>
        /// <param name="amount">收入确定总额</param>
        /// <param name="by">比例</param>
        /// <returns></returns>
        private decimal[] Allocate(decimal amount, int by)
        {
            decimal lowResult = amount / by;
            lowResult = Math.Round(lowResult, 2);

            decimal hightResult = lowResult + 0.01m;

            int remainder = (int)amount / by;
            decimal[] results = new decimal[by];
            for (int i = 0; i < remainder; i++) results[i] = hightResult;
            for (int i = remainder; i < by; i++) results[i] = lowResult;
            return results;
        }
    }
}
