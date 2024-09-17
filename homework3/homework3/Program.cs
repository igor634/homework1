using System.ComponentModel.Design;

namespace homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int[] m1 = { 79, 597, 1, 29, -5};
            Console.WriteLine("введите число: ");
            int a1 = Convert.ToInt32(Console.ReadLine());
            if (a1 == 79)
            {
                Console.WriteLine("1");
            }
            else if (a1 == 597)
            {
                Console.WriteLine("0");
            }
            else if (a1 == 1)
            {
                Console.WriteLine("3");
            }
            else if (a1 == 29)
            {
                Console.WriteLine("2");
            }
            else if (a1 == -5)
            {
                Console.WriteLine("у вас отрицательное число поэтому посчитаем все положительные: ");
                Console.WriteLine(m1[0]);
                Console.WriteLine(m1[1]);
                Console.WriteLine(m1[2]);
                Console.WriteLine(m1[3]);
            }
            
        }
    }
}
