using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway
{
    /// <summary>
    /// 摘要：
    ///     人员查找器
    /// 说明：
    ///     从数据库中读取人员信息，它和入口一起创建新的入口对象。
    /// </summary>
    public class PersonFinder
    {
        public PersonGateway Find(long id)
        {
            return null;
        }

        public List<PersonGateway> FindResponsibles()
        {
            return null;
        }
    }
}
