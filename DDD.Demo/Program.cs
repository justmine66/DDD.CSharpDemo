using DDD.Demo.src.Domain_Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DDD.Demo.src
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Read();
        }

        static void domainModelTest()
        {
            //Product word = Product.NewWordProcessor("文字处理软件立即入账");
            Product calc = Product.NewSpreadsheet("Thinking Calc");
            //Product db = Product.NewDatabase("Thinking DB");
            Contract contract = new Contract(calc, 10.23m, DateTime.UtcNow);
            calc.CalculateRevenueRecognitions(contract);
        }
    }
}
