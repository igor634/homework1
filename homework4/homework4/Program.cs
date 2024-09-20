namespace homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число: ");
            int a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
            int a2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 3 число: ");
            int a3 = Convert.ToInt32(Console.ReadLine());

            int max = method(a1, a2, a3);

            Console.WriteLine($"Самое максимальное число из трёх чисел это {max}");

        }
        static int method(int a, int b, int c){
            int max = a;
        if (b > max){
            max = b;
            }
        if (c > max){
            max = c; 
            }
        return max;
        }

    }
}
