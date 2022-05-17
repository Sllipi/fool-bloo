using System;

namespace Home1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dossier = { "Петров Роман Анатольевич", "Федотов Виктор Сергеевич", "Черний Иван Сергеевич" };
            string[] post = { "Слесарь", "Грамист", "Программист" };
            string[] menu = { "Добавить", "Удалить", "Посмотреть все досье", "Поиск по фамилии", "Выход" };
            int index = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ResetColor();
                Console.WriteLine("\t\tМеню");

                for (int i = 0; i < menu.Length; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index != 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != menu.Length - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 0:
                                addDossier(ref dossier, ref post);
                                break;
                            case 1:
                                dossier = deleteDossier(dossier, post);
                                break;
                            case 2:
                                Case2(ref dossier, ref post);
                                break;
                            case 3:
                                foundSurname(dossier, post);
                                break;
                            case 4:
                                exit();
                                break;
                        }
                        break;
                }
            }
        }
        private static void Case2(ref string[] dossier, ref string[] post)
        {
            outputAllDossiers(dossier, post);
            Console.ReadKey();
            cler();
        }
        static void foundSurname(string[] arrayDosier, string[] arrayPost)
        {
            string name;
            int indexArray = -1;
            Console.WriteLine("Чтобы найти досье, напишите полностью фамилию");
            name = Console.ReadLine();
            for (int i = 0; i < arrayDosier.Length; i++)
            {
                if (arrayDosier[i].StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    indexArray = i;
                    break;
                }
            }
            if (indexArray == -1)
            {
                Console.WriteLine("Такое досье не было найдено!");
            }
            else
            {
                Console.WriteLine("Досье найдено!");
                Console.WriteLine((indexArray + 1) + "-" + arrayDosier[indexArray] + "-" + arrayPost[indexArray]);
            }
            Console.ReadKey();
            cler();
        }
        static void exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }
        static void addDossier(ref string[] arrayDossier, ref string[] arrayPost)
        {
            Console.SetCursorPosition(0, 7);
            string[] copiDossier = new string[arrayDossier.Length + 1];
            string[] copiPost = new string[arrayPost.Length + 1];

            for (int i = 0; i < arrayDossier.Length; i++)
            {
                copiDossier[i] = arrayDossier[i];
                copiPost[i] = arrayPost[i];
            }

            arrayDossier = copiDossier;
            arrayPost = copiPost;
            text("Введите Фамилию Имя Отчество", ConsoleColor.Magenta);
            copiDossier[arrayDossier.Length - 1] = Console.ReadLine();
            text("Введите должность", ConsoleColor.Magenta);
            copiPost[arrayPost.Length - 1] = Console.ReadLine();

            text(("Вы добавели " + (arrayDossier.Length) + ") " + arrayDossier[arrayDossier.Length - 1] + " - " + arrayPost[arrayPost.Length - 1]), ConsoleColor.Cyan);
            Console.ReadKey();
            cler();
        }
        static string[] deleteDossier(string[] arrayDossier, string[] arrayPost) // удаление
        {
            string[] copiDossier = new string[arrayDossier.Length - 1];
            string[] copiPost = new string[arrayPost.Length - 1];
            outputAllDossiers(arrayDossier, arrayPost);
            Console.Write("Введите номер сотрудника, которого вы хотите удалить: ");
            int deleteIndex = Convert.ToInt32(Console.ReadLine());
            text($"Вы удалили {arrayDossier[deleteIndex - 1]} - {arrayPost[deleteIndex - 1]}", ConsoleColor.Blue);

            for (int i = 0; i < deleteIndex - 1; i++)
            {
                copiDossier[i] = arrayDossier[i];
                copiPost[i] = arrayPost[i];
            }

            for (int i = deleteIndex; i < arrayDossier.Length; i++)
            {
                copiPost[i - 1] = arrayPost[i];
                copiDossier[i - 1] = arrayDossier[i];
            }
            arrayDossier = copiDossier;
            arrayPost = copiPost;
            Console.ReadKey();
            cler();
            return arrayDossier;
        }
        static void outputAllDossiers(string[] arrayDossier, string[] arrayPost)
        {
            Console.WriteLine("Список сотрудников");
            for (int i = 0; i < arrayDossier.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + arrayDossier[i] + " - " + arrayPost[i]);
            }
        }
        static void text(string message, ConsoleColor color = ConsoleColor.Red)
        {
            cler();
            Console.SetCursorPosition(0, 6);
            Console.ForegroundColor = color;
            Console.WriteLine(message + "\t\t\t\t\t");
            Console.ResetColor();
        }
        static void cler(int x = 0, int y = 6)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 15; i++)
            {
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t\t\t\t\t");
            }
            Console.SetCursorPosition(x, y);
        }

    }
}
// Задача:
// Будет 2 массива: 1) фио 2) должность.
// Описать функцию заполнения массивов – досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.
// Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
// Программа должна быть с меню, которое содержит пункты:
// 1) добавить досье.
// 2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
// 3) удалить досье
// 4) поиск по фамилии
// 5) выход