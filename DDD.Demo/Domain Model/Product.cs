using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Domain_Model
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        private string name;
        /// <summary>
        /// 确认策略
        /// </summary>
        private RecognitionStrategy recognitionStrategy;

        public Product(string name, RecognitionStrategy recognitionStrategy)
        {
            this.name = name;
            this.recognitionStrategy = recognitionStrategy;
        }

        /// <summary>
        /// 摘要：
        ///     文字处理入账软件
        /// 说明：
        ///     所有收入可立即入账
        /// </summary>
        /// <param name="name">产品名称</param>
        /// <returns></returns>
        public static Product NewWordProcessor(string name)
        {
            return new Product(name, new CompleteRecognitionStrategy());
        }

        /// <summary>
        /// 摘要：
        ///     电子表格入账软件
        /// 说明：
        ///     当天入账1/3；60天后再入账1/3；剩下的1/3，90天时入账。
        /// </summary>
        /// <param name="name">产品名称</param>
        /// <returns></returns>
        public static Product NewSpreadsheet(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(60, 90));
        }

        /// <summary>
        /// 摘要：
        ///     数据库入账软件
        /// 说明：
        ///     当天入账1/3；60天后再入账1/3；剩下的1/3，60天时入账。
        /// </summary>
        /// <param name="name">产品名称</param>
        /// <returns></returns>
        public static Product NewDatabase(String name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(30, 60));
        }

        /// <summary>
        /// 计算指定合同的收入酬劳
        /// </summary>
        /// <param name="contract">合同</param>
        public void CalculateRevenueRecognitions(Contract contract)
        {
            recognitionStrategy.CalculateRevenueRecognitions(contract);
        }
    }
}
