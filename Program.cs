using System.Diagnostics;
using System.Globalization;
using Exe_Fixacao_Interfaces.Entities;
using Exe_Fixacao_Interfaces.Services;
using Microsoft.VisualBasic;

namespace Exe_Fixacao_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateOnly duoDate = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy");
            Console.Write("Contract value: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Contract contract = new Contract(number, duoDate, amount);

            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            ContractService contractService = new ContractService(contract, months, new PaypalService()); //Instancia um novo serviço de contrato
            contractService.ProcessContract(contract, months); // Chama o método ProcessContract para calcular e adicionar as parcelas ao contrato

        }
    }
}