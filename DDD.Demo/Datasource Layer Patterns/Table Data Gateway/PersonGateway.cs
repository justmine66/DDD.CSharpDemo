using DDD.Demo.Datasource_Layer_Patterns.Table_Data_Gateway.Layer_SuperTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DDD.Demo.Datasource_Layer_Patterns.Table_Data_Gateway
{
    /// <summary>
    /// 摘要：
    ///     人员入口
    /// 说明：
    ///     连接数据库中人员数据表
    /// </summary>
    public class PersonGateway : DataGateway
    {
        /// <summary>
        /// 根据主键访问特定的行
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataRow this[int key]
        {
            get
            {
                string filter = $"id = {key}";
                return this.Table.Select(filter)[0];
            }
        }

        public override string TableName => "persons";

        public override DataTable Table => this.Data.Tables[TableName];

        public IDataReader FindAll()
        {
            string sql = "select * from person";
            return new OleDbCommand(sql, null).ExecuteReader();
        }

        public IDataReader FindWithLastName(string lastName)
        {
            string sql = "select * from person where lastname = ?";
            IDbCommand comm = new OleDbCommand(sql, null);
            comm.Parameters.Add(new OleDbParameter("@lastName", lastName));
            return comm.ExecuteReader();
        }

        public void Update(int key,string lastName,string firstName,long numberOfDependents)
        {
            //示例
            this.LoadAll();
            this[0]["lastName"] = "justmine";
            this.Holder.Update();
        }

        public int Insert(string lastName, string firstName, long numberOfDependents)
        {
            return 0;
        }

        public void Delete(int key)
        {

        }
    }
}
