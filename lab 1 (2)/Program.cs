using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;




try
{
    Console.WriteLine("Завдання 1");
    S1();
    Console.WriteLine("Завдання 2");
    S2();
    Console.WriteLine("Завдання 3");
    S3();
}
catch (Exception e)
{
    Console.WriteLine("Error." + e.Message);
}
//Завдання 1
void S1()
{

    List<string> data = new List<string>
        {
            "1,Вася",
            "2,Коля",
            "3,Маша",
        };
    Console.WriteLine("Якщо бажаєте виконати пошук елемента за id - натиснiть 1\nЯкщо бажаєте виконати пошук елемента за UserName - натиснiть 2");
    int InputOption = int.Parse(Console.ReadLine());
    if (InputOption == 1)
    {
        Console.WriteLine("Введiть id елемента:");
        string id = Convert.ToString(Console.ReadLine());
        string result = FindElementById(data,
            id);
        if (result != null)
        {
            Console.WriteLine("Елемент знайдено: " + result);
        }
        else
        {
            Console.WriteLine("Елемент не знайдено.");
        }
    }
    else if (InputOption == 2)
    {
        Console.WriteLine("Введiть UserName елемента:");
        string UserName = Convert.ToString(Console.ReadLine());
        string result = FindElementByUserName(data, UserName);
        if (result != null)
        {
            Console.WriteLine("Елемент знайдено: " + result);
        }
        else
        {
            Console.WriteLine("Елемент не знайдено.");
        }
    }
    else
    {
        Console.WriteLine("Вибраної вами опцiї не iснує");
    }

}

string FindElementById(List<string> data, string targetId)
{
    string result = data.FirstOrDefault(item =>
    {
        string[] parts = item.Split(',');
        return parts.Length == 2 && parts[0] == targetId;
    });

    return result;
}
string FindElementByUserName(List<string> data, string targetUserName)
{
    string result = data.FirstOrDefault(item =>
    {
        string[] parts = item.Split(',');
        return parts.Length == 2 && parts[1] == targetUserName;
    });

    return result;
}




//Завдання 2
void S2()
{

    Dictionary<int, string> dictionary = new Dictionary<int, string>
        {
            { 1, "Value1" },
            { 3, "Value3" },
            { 5, "Value5" },
            { 7, "Value7" },

        };

    Console.WriteLine("Введiть значення ключа");

    int targetKey = int.Parse(Console.ReadLine());

    int resultKey = dictionary.Keys.Where(key => key >= targetKey).DefaultIfEmpty().Min();

    if (resultKey != default)
    {
        Console.WriteLine($"Найменший ключ, який бiльший або дорiвнює {targetKey}: {resultKey}");

        string jsonDictionary = JsonSerializer.Serialize(dictionary);
        Console.WriteLine($"Словник у JSON: {jsonDictionary}");
        string jsonFilePath = @"D:\lab1(2)";
        File.WriteAllText(jsonFilePath, jsonDictionary);
    }
    else
    {
        Console.WriteLine($"Немає ключа, який бiльший або дорiвнює {targetKey}. Повертається null.");
    }
}
//Завдання 3
void S3()
{
    List<string> A = new List<string> { "abc", "def", "ghi" };

    List<char> result = A.Select(str => str.First()).OrderByDescending(str => str).ToList();

    Console.WriteLine(string.Join("", result));
}
