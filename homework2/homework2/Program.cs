namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите год: ");
            int a1 = Convert.ToInt32(Console.ReadLine());
            
            

            if ((a1 % 4 == 0 && a1 % 100 != 0) || (a1 % 400 == 0))
                Console.WriteLine($"{a1} -  високосный");
            else
                Console.WriteLine($"{a1} - невисокосный");
        }
    }
}
