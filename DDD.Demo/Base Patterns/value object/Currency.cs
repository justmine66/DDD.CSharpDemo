using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.value_object
{
    /// <summary>
    /// 货币
    /// </summary>
    public class Currency
    {
        private CurrencyOptions currencyOption;
        private sbyte fractionDigits;

        public Currency() { }
        public Currency(CurrencyOptions currencyOption, sbyte fractionDigits)
        {
            this.currencyOption = currencyOption;
            this.fractionDigits = fractionDigits;
        }
        public Currency(CurrencyOptions currencyOption)
        {
            this.currencyOption = currencyOption;
            this.fractionDigits = (int)RoundingMode.Default;
        }

        /// <summary>
        /// 获取货币默认的小数位数
        /// </summary>
        /// <returns></returns>
        public sbyte GetDefaultFractionDigits()
        {
            return this.fractionDigits = 2;
        }

        /// <summary>
        /// 设置货币的小数位数
        /// </summary>
        /// <returns></returns>
        public void SetFractionDigits(sbyte fractionDigits)
        {
            this.fractionDigits = fractionDigits;
        }

        public override bool Equals(object other)
        {
            return (other is Currency) && this.Equals(other as Currency);
        }
        public bool Equals(Currency other)
        {
            return this.fractionDigits == other.fractionDigits && this.currencyOption == other.currencyOption;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
