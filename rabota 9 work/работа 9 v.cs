using System;
using System.Numerics;
namespace работа_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            bool again = true; // флаг для продолжения да или нет программы
            Console.WriteLine("Практическая работа 9 \n");
            Console.WriteLine("Добрый день.");
            Console.Write("Введите размерность массива:");
            int n = 0;
            int left, right;
            bool oneOrTwo = true; // флаг ввод размерности 
            while (again)
            {
                while (true)
                {
                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine()); //ввод размерности
                        if (n <= 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка.Размерность должна быть больше 0\n");
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (OverflowException oex)
                    {
                        oneOrTwo = false;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n Ошибка.{oex.Message} ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    catch (FormatException fex)
                    {
                        oneOrTwo = false;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n Ошибка.{fex.Message}. Введите целое число.\n");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    catch (Exception ex)
                    {
                        oneOrTwo = false;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n Ошибка.{ex.Message} ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                }
                bool error2 = true; // флаг обнаружения неправильного формата в 1 или 2
                while (error2)
                {
                    Console.WriteLine("\nХотите заполнить массив самостоятельно или генератором случайных чисел? (если самостоятельно - введите 1/генератором - 2 ");
                    string meaning = Console.ReadLine();
                    int[] array = new int[n];
                    long multiplication = 1;
                    int i = 0;
                    int j = 1;
                    switch (meaning)
                    {
                        case "1":
                            error2 = false;
                            Console.WriteLine("Вы значится захотели самостоятельно заполнить массив");
                            for (i = 0; i < n; i++)
                            {
                                bool oneOrTwo3 = true; // флаг для проверки вводимых элементов
                                while (oneOrTwo3)
                                {
                                    Console.Write($"Введите {i} элемент массива: ");
                                    try
                                    {
                                        array[i] = Convert.ToInt32(Console.ReadLine());
                                        oneOrTwo3 = false; //если ввели верно число
                                    }
                                    catch (IndexOutOfRangeException ioorex)
                                    {
                                        oneOrTwo3 = true;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n Ошибка.{ioorex.Message} ");
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                    }
                                    catch (OverflowException oex)
                                    {
                                        oneOrTwo3 = true;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n Ошибка.{oex.Message} ");
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                    }
                                    catch (FormatException fex)
                                    {
                                        oneOrTwo3 = true;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n Ошибка.{fex.Message}. Введите целое число.\n");
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                    }
                                    catch (Exception ex)
                                    {
                                        oneOrTwo3 = true;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n Ошибка.{ex.Message} ");
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                    }
                                }
                            }
                            int count = 0;
                            for (j = 1; j < n; j += 2)
                            {
                                if (array[j] % 2 != 0)//если значение не четное
                                {
                                    multiplication *= array[j];
                                    count += 1;
                                }
                            }
                            if (count == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Нет подобающих чисел для произведения");
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Произведение нечетных чисел = {multiplication}");
                            }
                            break;
                        case "2":
                            error2 = false;
                            Console.WriteLine("Сдается мне вы хотите чтобы числа сами в рандоме ввелись");
                            bool error1 = true; // флаг для обнаружения ошибок диапозонов
                            while (error1)
                            {
                                try
                                {
                                    Console.Write("Введите диапозон левой границы:");
                                    left = Convert.ToInt32(Console.ReadLine()); // левая граница диапощзона
                                    Console.Write("Введите диапозон правой границы:");
                                    right = Convert.ToInt32(Console.ReadLine()); // правая граница диавпозона
                                    Random r = new Random();
                                    if (left < right)
                                    {
                                        error1 = false;
                                        for (i = 0; i < n; i++)
                                        {
                                            array[i] = r.Next(left, right+1);
                                            Console.Write(array[i] + " ");
                                        }
                                        i++;
                                        Console.WriteLine(); // перенос строки
                                        count = 0; // кол-во всех нечетных элементов массив
                                        for (j = 1; j < n; j += 2)
                                        {
                                            if (array[j] % 2 != 0)//если значение не четное
                                            {
                                                multiplication *= array[j];
                                                count ++;
                                            }
                                        }
                                        if (count == 0)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Нет подобающих чисел для произведения");
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Произведение нечетных чисел = {multiplication}");
                                        }
                                    }
                                    else
                                    {
                                        error1 = true;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка.Левый диапозон должен быть меньше правого");
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                    }
                                }
                                catch (IndexOutOfRangeException ioorex)
                                {
                                    error1 = true;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\n Ошибка.{ioorex.Message} ");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                }
                                catch (OverflowException oex)
                                {
                                    error1 = true;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\n Ошибка.{oex.Message} ");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                }
                                catch (FormatException fex)
                                {
                                    error1 = true;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\n Ошибка.{fex.Message}. Введите целое число.\n");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                }
                                catch (Exception ex)
                                {
                                    error1 = true;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\n Ошибка.{ex.Message} ");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                }
                            }
                            break;
                            default:
                            error2 = true;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка. Введите 1 или 2");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
                bool OneOrTwo4 = false; // флаг проверки ввода 1 или 2
                while (!OneOrTwo4)
                {
                    Console.WriteLine("\nХотите продолжить? (да/нет): ");
                    string answer = Console.ReadLine(); //cчитывание ответа
                    if (answer == "нет" || answer == "Нет" || answer == "НЕТ")
                    {
                        Console.WriteLine("Конец.Завершение программы *_-");
                        again = false;
                        OneOrTwo4 = true;
                    }
                    else if (answer == "да" || answer == "Да" || answer == "ДА")
                    {
                        OneOrTwo4 = true;
                        Console.Clear();
                        Console.Write("Введите размерность массива:");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка.Введите да или нет");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

