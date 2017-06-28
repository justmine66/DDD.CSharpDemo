using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DDD.Demo.Table_Module
{
    /// <summary>
    /// 确定收入类
    /// </summary>
    [Table(name: "RevenueRecognitions", Schema = "dbo")]
    public class RevenueRecognition
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 合同标识
        /// </summary>
        public int contractID { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 收入确定额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
