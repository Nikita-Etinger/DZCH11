using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Q1()
    {

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        Console.Write("Введите относительный путь к директории (например, \\test): ");
        string relativePath = Console.ReadLine();


        string fullPath = baseDirectory+relativePath;
        Console.Write(fullPath);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
            Console.WriteLine($"Директория {fullPath} создана.");
        }
        else
        {
            Console.WriteLine($"Директория {fullPath} уже существует.");
        }


        string filePath1 = Path.Combine(fullPath, "1.txt");
        string filePath2 = Path.Combine(fullPath, "2.txt");

        File.WriteAllText(filePath1, "apple banana orange hello cat dog elephant hello bird tree hello world hello universe hello");
        File.WriteAllText(filePath2, "sun moon star hello planet ocean hello mountain hello hello river forest hello hello sky");

        Console.WriteLine($"Файлы {filePath1} и {filePath2} созданы и заполнены.");

        Console.Write("Введите слово для поиска: ");
        string searchWord = Console.ReadLine();

        SearchWordInFiles(filePath1, searchWord);
        SearchWordInFiles(filePath2, searchWord);
    }

    static void SearchWordInFiles(string filePath, string searchWord)
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            string[] words = content.Split(' ', '\n', '\r', '\t', '.', ',');

            bool wordFound = words.Contains(searchWord);

            Console.WriteLine($"В файле {filePath}:");
            Console.WriteLine($"Содержится ли слово '{searchWord}': {wordFound}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Файл {filePath} не найден.");
        }
    }

    static void Q2()
    {
        string inputString = "Hi! My name is Elena, im living in Pushkin street, 23! I'm 19 years old!";


        string resultString = RemoveNumbersAndSpecialCharacters(inputString);

        Console.WriteLine(resultString);
    }

    static string RemoveNumbersAndSpecialCharacters(string input)
    {

        string pattern = @"[^a-zA-Z,\s]"; //\s пробел сохраняю,запятую сохраняю
        string result = Regex.Replace(input, pattern, "");

        return result;
    }


    static void Main()
    {

       Q1();
       //Q2();
    }
        
}