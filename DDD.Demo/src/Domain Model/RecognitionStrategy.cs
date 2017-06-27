using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Domain_Model
{
    /// <summary>
    /// 收入确定策略基类，所有的确定策略都需实现此类。
    /// </summary>
    public abstract class RecognitionStrategy
    {
        public abstract void CalculateRevenueRecognitions(Contract contract);
    }
}
