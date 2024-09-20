namespace homework4_B_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число: ");
            int a1 = Convert.ToInt32(Console.ReadLine());

        }
        int factorial(int a1)
        {
            if (a1 == 1);

            return a1 * factorial(a1 - 1);
            Console.WriteLine(factorial(a1));
        }
        

    }
}
