namespace homework2_B_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool playAgain = true;

            while (playAgain)
            {
                
                int secretNumber = random.Next(1, 15);
                int attempts = 5;  
                bool numberGuessed = false;

                Console.WriteLine("Компьютер загадал число от 1 до 15. Попробуйте угадать!");

                
                while (attempts > 0 && !numberGuessed)
                {
                    Console.Write($"У вас {attempts} попыток. Введите ваше число: ");
                    int guess;

                    
                    if (int.TryParse(Console.ReadLine(), out guess))
                    {
                        if (guess == secretNumber)
                        {
                            Console.WriteLine("Поздравляем! Вы угадали число!");
                            numberGuessed = true;
                        }
                        else if (guess > secretNumber)
                        {
                            Console.WriteLine("Загаданное число меньше.");
                        }
                        else
                        {
                            Console.WriteLine("Загаданное число больше.");
                        }

                        attempts--;  
                    }
                    else
                    {
                        Console.WriteLine("Введите корректное число!");
                    }
                }

                if (!numberGuessed)
                {
                    Console.WriteLine($"Вы проиграли! Загаданное число было: {secretNumber}");
                }

                
                Console.Write("Хотите сыграть ещё раз? (y/n): ");
                string response = Console.ReadLine().ToLower();

                if (response != "y")
                {
                    playAgain = false;
                    Console.WriteLine("Спасибо за игру!");
                }
            }
        }  
    }
}
