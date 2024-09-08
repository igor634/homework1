namespace Homework1_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите число: ");

            //float f1 = Convert.ToSingle(Console.ReadLine());
            //Console.WriteLine("Введите второе число: ");
            //float f2 = Convert.ToSingle(Console.ReadLine());
            //Console.WriteLine(String.Format("{0:F2}", $"{f1} + {f2} =  {f1 + f2}"));
            Console.Write("Введите первое число: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Вычисляем сумму
            double sum = num1 + num2;

            // Выводим результат с округлением до двух знаков после запятой
            Console.WriteLine("Сумма: {0:F2}", sum);
        }
    }
}
