using DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.registry.singleton
{
    /// <summary>
    /// 单子注册表
    /// </summary>
    public class Registry
    {
        //使用一个静态变量来保存唯一的实例
        private static Registry getInstance()
        {
            return soleInstance;
        }
        private static Registry soleInstance = new Registry();

        //所有存储在注册表中的数据都存储在这个注册表实例中
        protected PersonFinder personFinder = new PersonFinder();
        public static PersonFinder PersonFinder()
        {
            return getInstance().personFinder;
        }

        ///通过创建一个唯一实例来初始化注册表
        public static void Initialize()
        {
            soleInstance = new Registry();
        }

        public static void InitializeStub()
        {
            soleInstance = new RegistryStub();
        }
    }
}
