using DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.registry.singleton
{
    /// <summary>
    /// 查找器服务桩
    /// </summary>
    public class PersonFinderStub
    {
        public PersonGateway Find(long id)
        {
            //直接返回硬编码的人员行数据入口
            return new PersonGateway("Flower", "Martin", 10);
        }
    }
}
