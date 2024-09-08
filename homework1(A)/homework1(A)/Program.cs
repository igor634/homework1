namespace homework1_A_
{
    internal class Program
    {
        static void Main(string[] args)
        {
    
            Console.WriteLine("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{number} + {number2} = {number + number2}");
            Console.WriteLine("Введите число: ");
            int number3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int number4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{number3} - {number4} = {number3 - number4}");
            Console.WriteLine("Введите число: ");
            int number5 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int number6 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{number5} * {number6} = {number5 * number6}");
            Console.WriteLine("Введите число: ");
            int number7 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int number8 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{number7} / {number8} = {number7 / number8}");

            ;
        }
    }
}
