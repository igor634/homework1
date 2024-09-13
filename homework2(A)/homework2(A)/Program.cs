using System.ComponentModel.Design;

namespace homework2_A_
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("введите первое число: ");
            int a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите второе число: ");
            int a2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("выберете действие (-, *, /, %): ");
            string operation = Console.ReadLine();
            int result = 0;
            switch(operation)
            {
             case "+":
             result = a1 + a2;
             break;

             case "-":
             result = a1 - a2;
             break;

             case "*":
             result = a1 * a2;
             break;
             
             case "/":
             result = a1 / a2;
             break;
             
             default: Console.WriteLine("error");
             break;
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}
