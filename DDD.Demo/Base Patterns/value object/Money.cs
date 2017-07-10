using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.value_object
{
    /// <summary>
    /// 摘要：
    ///     表示钱的标准
    /// </summary>
    public class Money
    {
        /// <summary>
        /// 金额，使用最小货币单位来衡量（eg：分）
        /// </summary>
        private long amount;

        /// <summary>
        /// 货币
        /// </summary>
        private Currency currency;

        /// <summary>
        /// 舍入模式
        /// </summary>
        private int roundingMode;

        public static Money Dollars(decimal amount)
        {
            var cur = new Currency(CurrencyOptions.Dollar_US);
            return new Money(amount, cur);
        }

        public static Money RMBs(decimal amount)
        {
            var cur = new Currency(CurrencyOptions.RMB_CH);
            return new Money(amount, cur);
        }

        #region 为实际生活中的不同数字形式提供不同的构造函数
        public Money(double amount)
        {
            this.amount = (long)Math.Round(amount * this.centFactor());
        }
        public Money(double amount, int roundingMode)
        {
            this.amount = (long)Math.Round(amount * this.centFactor());
            this.roundingMode = roundingMode;
        }
        public Money(double amount, Currency currency)
        {
            this.currency = currency;
            this.amount = (long)Math.Round(amount * this.centFactor());
        }
        public Money(decimal amount, Currency currency)
        {
            this.currency = currency;
            this.amount = (long)Math.Round(amount * this.centFactor());
        }
        public Money(decimal amount, int roundingMode)
        {
            this.amount = (long)Math.Round(amount * this.centFactor());
            this.roundingMode = roundingMode;
        }
        public Money(long amount, Currency currency)
        {
            this.currency = currency;
            this.amount = amount * this.centFactor();
        }
        #endregion

        #region 分子因子，即最小单位因子 
        private static int[] cents = { 1, 10, 100, 1000 };
        private int centFactor()
        {
            return cents[currency.GetDefaultFractionDigits()];
        }
        #endregion

        #region 为实际生活中的提供不同的金额获取方式
        public decimal Amount()
        {
            int fractionDigits = currency.GetDefaultFractionDigits();
            decimal.TryParse((this.amount / fractionDigits).ToString(), out decimal result);
            return decimal.Round(result, fractionDigits);
        }
        #endregion

        public Currency Currency()
        {
            return this.currency;
        }

        public override bool Equals(object other)
        {
            return (other is Money) && this.Equals(other as Money);
        }
        public virtual bool Equals(Money other)
        {
            return this.currency.Equals(other.currency) && this.amount == other.amount;
        }

        public override int GetHashCode()
        {
            return (int)(this.amount ^ (amount >> 32));
        }

        #region 基本操作

        public Money Add(Money other)
        {
            this.assertSameCurrencyAs(other);
            return this.newMoney(this.amount + other.amount);
        }

        public Money Substract(Money other)
        {
            this.assertSameCurrencyAs(other);
            return this.newMoney(this.amount - other.amount);
        }

        public int CompareTo(object other)
        {
            return this.CompareTo(other as Money);
        }

        public bool GreaterThan(Money other)
        {
            return this.CompareTo(other) > 0;
        }

        public sbyte CompareTo(Money other)
        {
            this.assertSameCurrencyAs(other);
            if (this.amount < other.amount) return -1;
            else if (this.amount > other.amount) return 1;
            else return 0;
        }

        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="roundingMode">舍入模式</param>
        /// <returns></returns>
        public Money Multiply(decimal amount, int roundingMode)
        {
            return new Money(this.Amount() * amount, roundingMode);
        }
        public Money Multiply(decimal amount)
        {
            return this.Multiply(amount, (int)RoundingMode.Default);
        }
        public Money Multiply(double amount)
        {
            return this.Multiply(new decimal(amount), (int)RoundingMode.Default);
        }

        private void assertSameCurrencyAs(Money arg)
        {

        }
        private Money newMoney(long amount)
        {
            return new Money(amount);
        }

        #endregion

        /// <summary>
        /// 多个对象之间平分资金，并不丢失小金额。
        /// </summary>
        /// <param name="n">平分比例</param>
        /// <returns></returns>
        public Money[] Allocate(int n)
        {
            Money lowResult = new Money(this.amount / n);
            Money highResult = new Money(lowResult.amount + 1);
            Money[] results = new Money[n];
            int remainder = (int)this.amount % n;
            for (int i = 0; i < remainder; i++) results[i] = highResult;
            for (int i = remainder; i < n; i++) results[i] = lowResult;
            return results;
        }

        /// <summary>
        /// 多个对象之间按任意比例定量平分资金，并不丢失小金额。
        /// </summary>
        /// <param name="n">比例定量</param>
        /// <returns></returns>
        public Money[] Allocate(int[] rations)
        {
            long total = 0;
            for (int i = 0; i < rations.Length; i++) total += rations[i];
            long remainder = this.amount;
            Money[] results = new Money[rations.Length];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = this.newMoney(amount * (rations[i] / total));
                remainder = results[i].amount;
            }
            for (int i = 0; i < remainder; i++)
            {
                results[i].amount++;
            }
            return results;
        }
    }
}
