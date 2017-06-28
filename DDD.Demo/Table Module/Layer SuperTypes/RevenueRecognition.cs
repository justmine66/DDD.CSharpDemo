using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Table_Module.Layer_SuperTypes
{
    /// <summary>
    /// 收入确定表
    /// </summary>
    public class RevenueRecognition : TableModule
    {
        public RevenueRecognition(DataSet ds) : base(ds, "RevenueRecognitions")
        {
        }

        public int Insert(int ContractID, decimal amount, DateTime whenSinged)
        {
            DataRow newRow = table.NewRow();
            int id = this.GetNextID();
            newRow["ID"] = id;
            newRow["contractID"] = ContractID;
            newRow["amount"] = amount;
            newRow["date"] = $"{whenSinged:s}";
            table.Rows.Add(newRow);
            return id;
        }

        //// <summary>
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
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        private int GetNextID()
        {
            return new Random().Next(0, int.MaxValue);
        }

        /// <summary>
        /// 汇总某个合同给定日期之前的所有已经确认的收入
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="asof"></param>
        /// <returns></returns>
        public decimal RecognizedRevenue(int contractID, DateTime asof)
        {
            string filter = $"ContractID={contractID} AND date <= #{asof:d}#";
            DataRow[] rows = table.Select(filter);
            decimal result = decimal.Zero;
            foreach (DataRow row in rows) result += (decimal)row["amount"];
            return result;
        }
    }
}
