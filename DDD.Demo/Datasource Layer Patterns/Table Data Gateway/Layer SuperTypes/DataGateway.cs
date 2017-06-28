using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Datasource_Layer_Patterns.Table_Data_Gateway.Layer_SuperTypes
{
    /// <summary>
    /// 摘要：
    ///     数据入口
    /// 说明：
    ///     存储保持器并把数据集暴露给客户
    /// </summary>
    public abstract class DataGateway
    {
        public DataSetHolder Holder;
        public DataSet Data { get { return Holder.Data; } }

        /// <summary>
        /// 表名
        /// </summary>
        public abstract string TableName { get; }

        protected DataGateway()
        {
            this.Holder = new DataSetHolder();
        }

        protected DataGateway(DataSetHolder holder)
        {
            this.Holder = holder;
        }

        public void LoadAll()
        {
            string commandString = $"select * from {TableName}";
            Holder.FillData(commandString, TableName);
        }

        public void LoadWhere(string whereClause)
        {
            string commandString = $"select * from {TableName} where {whereClause}";
            Holder.FillData(commandString, TableName);
        }

        public abstract DataTable Table { get; }
    }
}
