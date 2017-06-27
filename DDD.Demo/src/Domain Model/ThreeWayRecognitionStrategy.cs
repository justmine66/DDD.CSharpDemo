using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.src.Domain_Model
{
    public class ThreeWayRecognitionStrategy : RecognitionStrategy
    {
        private int firstRecognitionOffset;
        private int secondRecognitionOffset;

        public ThreeWayRecognitionStrategy(int firstRecognitionOffset, int secondRecognitionOffset)
        {
            this.firstRecognitionOffset = firstRecognitionOffset;
            this.secondRecognitionOffset = secondRecognitionOffset;
        }

        public override void CalculateRevenueRecognitions(Contract contract)
        {
            decimal allocation = contract.GetRevenue();
            contract.AddRevenueRecognition(new RevenueRecognition(allocation / 3, contract.GetWhenSigned()));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation / 3, contract.GetWhenSigned().AddDays(firstRecognitionOffset)));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation / 3, contract.GetWhenSigned().AddDays(secondRecognitionOffset)));
        }
    }
}
