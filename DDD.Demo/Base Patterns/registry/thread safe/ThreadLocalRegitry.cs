using DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DDD.Demo.Base_Patterns.registry.thread_safe
{
    /// <summary>
    /// 摘要：
    ///     线程局部注册表
    /// 说明：
    ///     每一个线程自己唯一的注册表
    /// </summary>
    public class ThreadLocalRegitry
    {
        private static ConcurrentDictionary<int, ThreadLocalRegitry> instances = new ConcurrentDictionary<int, ThreadLocalRegitry>();

        /// <summary>
        /// 获取当前线程的注册表
        /// </summary>
        /// <returns></returns>
        public static ThreadLocalRegitry GetInstance()
        {
            return instances.GetOrAdd(Thread.CurrentThread.ManagedThreadId, (key) => { return new ThreadLocalRegitry(); });
        }

        //事物或会话边界调用下来方法
        //创建注册表实例，
        public static void Begin()
        {
            if (instances == null || instances.Count <= 0)
                instances.GetOrAdd(Thread.CurrentThread.ManagedThreadId, (key) => { return new ThreadLocalRegitry(); });
        }

        //释放注册表实例
        public static void End()
        {
            if (instances != null || instances.Count > 0)
                instances = null;
        }

        private PersonFinder personFinder = new PersonFinder();
        public static PersonFinder GetPersonFinder()
        {
            return GetInstance().personFinder;
        }
    }
}
