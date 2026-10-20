using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace работа_11._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            while (true)
            {
                //Console.Clear();
                string userString1;
                bool text = false; //флаг для обнаружения ошибки в тексте
                while (!text)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    //Console.Clear();
                    //Console.WriteLine("Практическая работа 11\n");
                    Console.Write("Введите строку: ");
                    userString1 = Console.ReadLine();
                    if(String.IsNullOrWhiteSpace(userString1))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка. Отсутствует текст");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        continue;
                    }
                    else
                    {
                        char[] userString2 = userString1.ToCharArray();
                        int countA = 0; //счетчик букв а
                        int countO = 0; //счетчик букв о
                        for (int i = 0; i < userString2.Length; i++)
                        {
                            if (userString2[i] == 'a' || userString2[i] == 'A' || userString2[i] == 'а' || userString2[i] == 'А')
                            {
                                countA++;
                            }
                            else if (userString2[i] == 'o' || userString2[i] == 'O' || userString2[i] == 'о' || userString2[i] == 'О')
                            {
                                countO++;
                            }
                        }
                        Console.WriteLine($" Букв А в строке: {countA}");
                        Console.WriteLine($" Букв О в строке: {countO}");
                        bool again = false;
                        while (!again)
                        {
                            Console.WriteLine(" \nХотите продолжить? (да/нет): ");
                            string selectKey = Console.ReadLine();
                            if (selectKey == "да" || selectKey == "Да" || selectKey == "ДА")
                            {
                                again = true;
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Blue;
                            }
                            else if (selectKey == "нет" || selectKey == "Нет" || selectKey == "НЕТ")
                            {
                                Console.WriteLine("**%Конец.(**__**)%**");
                                return;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Введите да или нет");
                                Console.BackgroundColor = ConsoleColor.Blue;
                            }
                        }
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
