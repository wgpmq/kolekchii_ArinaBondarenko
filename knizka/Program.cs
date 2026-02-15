using System;
using System.Collections;

class Program
{
    // Создаем телефонную книгу
    static Hashtable phoneBook = new Hashtable();

    static void Main()
    {
        while (true)
        {
           
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Удалить контакт");
            Console.WriteLine("3. Найти телефон по фамилии");
            Console.WriteLine("4. Найти фамилию по телефону");
            Console.WriteLine("5. Показать все контакты");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    RemoveContact();
                    break;
                case "3":
                    FindPhoneBySurname();
                    break;
                case "4":
                    FindSurnameByPhone();
                    break;
                case "5":
                    ShowAllContacts();
                    break;
                case "6":
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    static void AddContact()
    {
        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        Console.Write("Введите телефон: ");
        string phone = Console.ReadLine();

        // Проверяем, есть ли уже такая фамилия
        if (phoneBook.ContainsKey(surname))
        {
            Console.WriteLine("Такой контакт уже есть!");
            return;
        }

        phoneBook.Add(surname, phone);
        Console.WriteLine("Контакт добавлен!");
    }

    static void RemoveContact()
    {
        Console.Write("Введите фамилию для удаления: ");
        string surname = Console.ReadLine();

        if (phoneBook.ContainsKey(surname))
        {
            phoneBook.Remove(surname);
            Console.WriteLine("Контакт удален!");
        }
        else
        {
            Console.WriteLine("Контакт не найден!");
        }
    }

    static void FindPhoneBySurname()
    {
        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        if (phoneBook.ContainsKey(surname))
        {
            Console.WriteLine($"Телефон: {phoneBook[surname]}");
        }
        else
        {
            Console.WriteLine("Контакт не найден!");
        }
    }

    static void FindSurnameByPhone()
    {
        Console.Write("Введите телефон: ");
        string phone = Console.ReadLine();

        foreach (DictionaryEntry entry in phoneBook)
        {
            if (entry.Value.ToString() == phone)
            {
                Console.WriteLine($"Фамилия: {entry.Key}");
                return;
            }
        }

        Console.WriteLine("Телефон не найден!");
    }

    static void ShowAllContacts()
    {
        if (phoneBook.Count == 0)
        {
            Console.WriteLine("Книга пуста!");
            return;
        }

        Console.WriteLine("Все контакты:");
        foreach (DictionaryEntry entry in phoneBook)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
