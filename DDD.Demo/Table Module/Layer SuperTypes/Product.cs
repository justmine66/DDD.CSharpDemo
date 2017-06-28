using DDD.Demo.Table_Module.ValueoObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDD.Demo.Table_Module.Layer_SuperTypes
{
    /// <summary>
    /// 产品表
    /// </summary>
    public class Product : TableModule
    {
        public Product(DataSet ds) : base(ds, "Products")
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
        /// 获取给定主键的产品类型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>产品类型</returns>
        public ProductType GetProductType(int id)
        {
            string typeCode = this[id]["type"].ToString();
            Enum.TryParse(typeCode, out ProductType prodType);
            return prodType;
        }
    }
}
