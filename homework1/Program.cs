namespace homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Назовите ваше имя: ");
            var name = Console.ReadLine();
            Console.WriteLine($"{name}");
            Console.Write("Назовите ваш возраст: ");
            var age = Console.ReadLine();
            Console.WriteLine($"{age}");
            Console.Write("Назовите ваш вес: ");
            var weight = Console.ReadLine();
            Console.WriteLine($"{weight}");
            Console.WriteLine($"{name},{age} лет,вес:{weight}");
        }
    }
}
