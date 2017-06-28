using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Transaction_Script
{
    /// <summary>
    /// 确定收入类
    /// </summary>
    [Table(name: "RevenueRecognitions", Schema = "dbo")]
    public class RevenueRecognition
    {
        /// <summary>
        /// 合同标识
        /// </summary>
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractID { get; set; }

        public virtual Contract Contract { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [Key, Column(Order = 2)]
        public DateTime RecognizeOn { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
