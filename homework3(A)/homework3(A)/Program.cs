namespace homework3_A_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите количество строк матрицы: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int columns = int.Parse(Console.ReadLine());

           
            int[,] matrix = new int[rows, columns];

           
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            
            Console.WriteLine("\nМатрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            
            Console.WriteLine("\nСумма элементов каждой строки:");
            for (int i = 0; i < rows; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < columns; j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine($"Сумма строки {i + 1}: {rowSum}");
            }
        }
    }
}
