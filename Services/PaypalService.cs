using System;
using System.Collections.Generic;
using Exe_Fixacao_Interfaces.Entities;
using Exe_Fixacao_Interfaces.Services;

namespace Exe_Fixacao_Interfaces.Services
{
    class PaypalService : IOnlinePaymentService
    {
        //double amoutTotal = 0.0; usar caso nao tiver dando certo os dois valores
        
        public double Interest(double amount, int months)
        {
            double totalInterest = 0.0;
            for (int i = 1; i <= months; i++)
            {
                totalInterest = amount * (0.01 * i);
            }
            return totalInterest;
        }
        public double PaymentFee(double amount)
        {
            return amount * 0.02;
        }
    }
}
