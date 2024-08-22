namespace Exe_Fixacao_Interfaces.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateOnly Date { get; set; }

        public double TotalValue { get; set; }
        public Installment Installment { get; set; }
        //Lista de parcelas
        public List<Installment> List { get; set; }

        
        public Contract(int number, DateOnly date, double totalValue) //Installment não é passado aqui pois só é gerado depois de processar os valores. Pode ser nula ou não precisa passar embaixo no construtor.
        {
            Number = number;
            Date = date;
            TotalValue = totalValue; 
            Installment = null;
            List = new List<Installment>();
        }
        

    }
}
