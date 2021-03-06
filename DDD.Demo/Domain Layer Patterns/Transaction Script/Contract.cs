﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DDD.Demo.Transaction_Script
{
    /// <summary>
    /// 合同类
    /// </summary>
    [Table(name: "Contracts", Schema = "dbo")]
    public class Contract
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 签订时间
        /// </summary>
        public DateTime DateSigned { get; set; }

        /// <summary>
        /// 产品标识
        /// </summary>
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        /// <summary>
        /// 收入确定总额
        /// </summary>
        public decimal Revenue { get; set; }
    }
}
