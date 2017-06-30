using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Base_Patterns.gateway
{
    public interface IMessageGateway
    {
        void SendConfirmation(string orderID, int amount, string symbol);
    }
}
