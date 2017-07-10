﻿using DDD.Demo.Base_Patterns.value_object;
using DDD.Demo.Domain_Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DDD.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //domainModelTest();
            Console.Read();
        }

        static void domainModelTest()
        {
            //Product word = Product.NewWordProcessor("文字处理软件，立即入账");
            Product calc = Product.NewSpreadsheet("电子表格软件，按规则入账");
            //Product db = Product.NewDatabase("数据库软件，按规则入账");
            Contract contract = new Contract(calc, 10.23m, DateTime.UtcNow);
            calc.CalculateRevenueRecognitions(contract);
        }

        static void testAllocate2()
        {
            int[] allocation = { 3, 7 };
            Money[] result = Money.Dollars(0.05m).Allocate(allocation);
        }
    }
}
