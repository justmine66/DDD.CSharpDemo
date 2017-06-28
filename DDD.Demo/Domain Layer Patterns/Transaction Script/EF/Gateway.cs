using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Transaction_Script.EF
{
    /// <summary>
    /// 入口
    /// </summary>
    public class Gateway
    {
        private static Lazy<Gateway> _instance = new Lazy<Gateway>();
        public static Gateway Instance = _instance.Value;

        private static Lazy<IntegrationDBContext> _db = new Lazy<IntegrationDBContext>();
        private static IntegrationDBContext db = _db.Value;

        /// <summary>
        /// 查询某合同在指定日期前已经确人的收入额数据集
        /// </summary>
        /// <param name="contractID">合同标识</param>
        /// <param name="asof">截止日期</param>
        public IEnumerable<RevenueRecognition> FindRecognitionsFor(int contractID, DateTime asof)
        {
            var query = db.RevenueRecognitions
                .AsParallel()
                .Where(e => e.ContractID == contractID && e.RecognizeOn <= asof);
            return query.ToList();
        }

        /// <summary>
        /// 查询某合同数据集
        /// </summary>
        /// <param name="contractID">合同标识</param>
        public IEnumerable<Contract> FindContractFor(int contractID)
        {
            var query = db.Contracts
                .AsParallel()
                .Where(e => e.ID == contractID);
            return query.ToList();
        }
    }
}
