using DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.registry.singleton
{
    /// <summary>
    /// 注册表服务桩
    /// </summary>
    public class RegistryStub : Registry
    {
        public RegistryStub()
        {
            personFinderStub = new PersonFinderStub();
        }

        private PersonFinderStub personFinderStub;
    }
}
