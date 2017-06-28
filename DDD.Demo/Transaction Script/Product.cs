using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Transaction_Script
{
    /// <summary>
    /// 产品类
    /// </summary>
    [Table(name: "Products", Schema = "dbo")]
    public class Product
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
    }
}
