namespace Homework1_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            
            double sum = num1 + num2;

        
            Console.WriteLine("Сумма: {0:F2}", sum);
        }
    }
}
