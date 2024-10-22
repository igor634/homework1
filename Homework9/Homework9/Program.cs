using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\testfolder"; 
        string extensionFilter = ".txt"; 
        string showType = "both"; // Варианты: "files", "dirs", "both"
        int? modifiedWithinDays = 30; 

        ListDirectoryContents(directoryPath, extensionFilter, showType, modifiedWithinDays);
    }

    static void ListDirectoryContents(string path, string fileExtension = null, string show = "both", int? modifiedWithinDays = null)
    {
        if (!Directory.Exists(path))
        {
            Console.WriteLine("Директория не существует.");
            return;
        }

        DateTime currentDate = DateTime.Now;
        SearchOption searchOption = SearchOption.AllDirectories; 

        // Получаем файлы
        if (show == "files" || show == "both")
        {
            var files = Directory.GetFiles(path, "*", searchOption);
            foreach (var file in files)
            {
                // Фильтрация по расширению
                if (!string.IsNullOrEmpty(fileExtension) && Path.GetExtension(file) != fileExtension)
                {
                    continue;
                }

                // Фильтрация по дате изменения
                if (modifiedWithinDays.HasValue)
                {
                    DateTime lastModified = File.GetLastWriteTime(file);
                    if ((currentDate - lastModified).TotalDays > modifiedWithinDays.Value)
                    {
                        continue;
                    }
                }

                Console.WriteLine($"Файл: {file}");
            }
        }

        // Получаем директории
        if (show == "dirs" || show == "both")
        {
            var directories = Directory.GetDirectories(path, "*", searchOption);
            foreach (var dir in directories)
            {
                
                if (modifiedWithinDays.HasValue)
                {
                    DateTime lastModified = Directory.GetLastWriteTime(dir);
                    if ((currentDate - lastModified).TotalDays > modifiedWithinDays.Value)
                    {
                        continue;
                    }
                }

                Console.WriteLine($"Директория: {dir}");
            }
        }
    }
}
