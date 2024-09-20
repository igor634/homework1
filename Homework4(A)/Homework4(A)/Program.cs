using System.Security.Cryptography;

namespace Homework4_A_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a1 = 0;
            int a2 = 0;


            Console.WriteLine("Введите число: ");
             a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
             a2 = Convert.ToInt32(Console.ReadLine());
            
            int result = 0;

            number(a1, a2, out result);

            Console.WriteLine($"Остаток: {result}");
            int a3 = Convert.ToInt32(Console.ReadLine());

            void number(int a3, int a4, out int result)
            {
                result = a1 - a2;
            }
        }
    }
}
