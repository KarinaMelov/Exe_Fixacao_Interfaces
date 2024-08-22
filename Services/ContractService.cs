using System;
using System.Collections.Generic;
using Exe_Fixacao_Interfaces.Entities;
using Exe_Fixacao_Interfaces.Services;
using System.Globalization;

namespace Exe_Fixacao_Interfaces.Services
{
    class ContractService
    {

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(Contract contract, int months, IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            Console.WriteLine();
            Console.WriteLine("Calculations (1% monthly simple interest + 2% payment fee):");
            for (int i = 1; i <= months; i++)
            {
                // Defina a data de vencimento após a data do contrato adicionando x meses a data inicial.
                DateOnly dueDate = contract.Date.AddMonths(i);

                double interest = _onlinePaymentService.Interest(basicQuota, i);
                double updateQuota = basicQuota + interest; // Adiciona juros
                double paymentFee = _onlinePaymentService.PaymentFee(updateQuota);
                double fullQuota = updateQuota + paymentFee; // Adiciona taxa

                Console.WriteLine();
                // Exibe o detalhamento dos cálculos
                Console.WriteLine($"{basicQuota}" +
                    $" + 1% * {i} = {updateQuota.ToString("F2", CultureInfo.InvariantCulture)}");

                Console.WriteLine($"{updateQuota.ToString("F2", CultureInfo.InvariantCulture)} " +
                    $" + 2% = {fullQuota.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine(); // Para separar os cálculos das parcelas

                // Adicionar a parcela à lista de parcelas do contrato
                contract.List.Add(new Installment(dueDate, fullQuota));
            }

        }
    }
}
