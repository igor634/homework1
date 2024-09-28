namespace homework6_A_
{
    internal class Program
    {
        class RPNCalculator
        {
            public static double Evaluate(string expression)
            {
                Stack<double> stack = new Stack<double>();
                string[] tokens = expression.Split(' ');

                foreach (string token in tokens)
                {
                    
                    if (double.TryParse(token, out double number))
                    {
                        stack.Push(number);
                    }
                    else
                    {
                        // Если токен не число, то это оператор
                        double operand2 = stack.Pop();
                        double operand1 = stack.Pop();

                        switch (token)
                        {
                            case "+":
                                stack.Push(operand1 + operand2);
                                break;
                            case "-":
                                stack.Push(operand1 - operand2);
                                break;
                            case "*":
                                stack.Push(operand1 * operand2);
                                break;
                            case "/":
                                stack.Push(operand1 / operand2);
                                break;
                            default:
                                throw new ArgumentException($"Неверный оператор: {token}");
                        }
                    }
                }

                // Результат — это единственное оставшееся число в стеке
                return stack.Pop();
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Введите выражение в обратной польской записи (RPN):");
                string input = Console.ReadLine();

                try
                {
                    double result = Evaluate(input);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
