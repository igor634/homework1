namespace homework6
{
    internal class Program
    {
        class WordCounter
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите строку текста:");
                string input = Console.ReadLine();

                // Убираем знаки препинания и приводим текст к нижнему регистру
                string[] words = input.ToLower()
                .Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '(', ')', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();

               
                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        // Если слово уже есть в словаре, увеличиваем счётчик
                        wordCounts[word]++;
                    }
                    else
                    {
                        // Если слова ещё нет в словаре, добавляем его с начальным счётчиком 1
                        wordCounts.Add(word, 1);
                    }
                }

                
                Console.WriteLine("Количество повторений каждого слова:");
                foreach (var pair in wordCounts)
                {
                    Console.WriteLine($"Слово '{pair.Key}' встречается {pair.Value} раз(а)");
                }
            }
        }
    }
}
