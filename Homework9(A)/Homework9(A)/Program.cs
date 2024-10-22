using System;
using System.Collections.Generic;
using System.IO;

[Serializable] 
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student() { } 

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    
    public override string ToString()
    {
        return $"Имя: {Name}, Возраст: {Age}, Оценка: {Grade}";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    static string filePath = "students.bin"; 

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Сохранить студентов в файл");
            Console.WriteLine("3. Загрузить студентов из файла");
            Console.WriteLine("4. Вывести список студентов");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите действие: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    SaveStudentsToFile();
                    break;
                case 3:
                    LoadStudentsFromFile();
                    break;
                case 4:
                    DisplayStudents();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            Console.WriteLine();
        }
    }

   
    static void AddStudent()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст студента: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Введите оценку студента: ");
        double grade = double.Parse(Console.ReadLine());

        students.Add(new Student(name, age, grade));
        Console.WriteLine("Студент добавлен.");
    }

    // Метод для сохранения списка студентов в бинарный файл
    static void SaveStudentsToFile()
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(students.Count);
            foreach (var student in students)
            {
                writer.Write(student.Name);
                writer.Write(student.Age);
                writer.Write(student.Grade);
            }
        }

        Console.WriteLine("Студенты сохранены в файл.");
    }

    // Метод для загрузки списка студентов из бинарного файла
    static void LoadStudentsFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        students.Clear();

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                double grade = reader.ReadDouble();

                students.Add(new Student(name, age, grade));
            }
        }

        Console.WriteLine("Студенты загружены из файла.");
    }

   
    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Список студентов пуст.");
        }
        else
        {
            Console.WriteLine("Список студентов:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}