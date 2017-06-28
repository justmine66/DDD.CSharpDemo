using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DDD.Demo.Datasource_Layer_Patterns.Table_Data_Gateway.Layer_SuperTypes
{
    /// <summary>
    /// 数据集保持器
    /// </summary>
    public class DataSetHolder
    {
        public DataSet Data = new DataSet();
        private Hashtable DataAdapters = new Hashtable();

        public void FillData(string query, string tableName)
        {
            if (DataAdapters.Contains(tableName)) throw new Exception("");
            OleDbDataAdapter da = new OleDbDataAdapter(query, "");
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            da.Fill(Data, tableName);
            DataAdapters.Add(tableName, Data);
        }

        public void Update()
        {
            foreach (string table in DataAdapters.Keys)
                (DataAdapters[table] as OleDbDataAdapter).Update(Data, table);
        }

        public DataTable this[string tableName]
        {
            get
            {
                return this.Data.Tables[tableName];
            }
        }
    }
}
