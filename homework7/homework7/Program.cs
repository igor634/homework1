namespace homework7
{
    using System;

    public enum IncomeType
    {
        Salary,     
        Business,  
        Investments 
    }

    public class Income
    {
        public readonly IncomeType Type;
        public readonly decimal Amount;

        public Income(IncomeType type, decimal amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    public static class TaxConfig
    {
       
        public static readonly decimal SalaryTaxRate = 0.15m;     
        public static readonly decimal BusinessTaxRate = 0.25m;   
        public static readonly decimal InvestmentsTaxRate = 0.10m; 

       
        public static decimal TotalCollectedTaxes { get; private set; } = 0;

        
        public static decimal CalculateTax(Income income)
        {
            decimal taxRate = 0;

           
            switch (income.Type)
            {
                case IncomeType.Salary:
                    taxRate = SalaryTaxRate;
                    break;
                case IncomeType.Business:
                    taxRate = BusinessTaxRate;
                    break;
                case IncomeType.Investments:
                    taxRate = InvestmentsTaxRate;
                    break;
            }


            decimal taxAmount = income.Amount * taxRate;
            TotalCollectedTaxes += taxAmount; 
            return taxAmount;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
          
            Income salaryIncome = new Income(IncomeType.Salary, 1000);
            Income businessIncome = new Income(IncomeType.Business, 5000);
            Income investmentsIncome = new Income(IncomeType.Investments, 2000);

            Console.WriteLine($"Налог на зарплату: {TaxConfig.CalculateTax(salaryIncome)}");
            Console.WriteLine($"Налог на бизнес: {TaxConfig.CalculateTax(businessIncome)}");
            Console.WriteLine($"Налог на инвестиции: {TaxConfig.CalculateTax(investmentsIncome)}");

            
            Console.WriteLine($"Общая сумма собранных налогов: {TaxConfig.TotalCollectedTaxes}");
        }
    }
}