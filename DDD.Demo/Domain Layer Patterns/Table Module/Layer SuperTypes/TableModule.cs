using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Table_Module.Layer_SuperTypes
{
    /// <summary>
    /// 表模块超类
    /// </summary>
    public class TableModule
    {
        protected DataTable table;

        protected TableModule(DataSet ds, string tableName)
        {
            table = ds.Tables[0];
        }
    }
}
