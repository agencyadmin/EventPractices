
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPractices
{

    class Program
    {
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowNumber;
            numberReader.NumberEnteredEvent += MakeArray;

            while (true)
            {
                try
                {

                    numberReader.Read();
                }


                catch (Exception ex) when (ex is FormatException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 1");

                }
                catch (Exception ex) when (ex is ArgumentException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 2");

                }
                catch (Exception ex) when (ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 3");

                }
                catch (Exception ex) when (ex is NotImplementedException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 4");

                }
                catch (Exception ex) when (ex is TimeoutException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 5");

                }
                catch (Exception ex) when (ex is NotSupportedException)
                {
                    Console.WriteLine("Подтверждаем!!!! Сработало пользовательское исключение 6");

                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Сработало системное исключение: {ex.GetType}, {ex.Message}, {ex.StackTrace}, {ex.Message}");

                }

              
            }
            static void ShowNumber(int number)
            {
                switch (number)
                {
                    case 1: Console.WriteLine("Введено значение 1"); break;
                    case 2: Console.WriteLine("Введено значение 2"); break;
                }

            }

            static void MakeArray(int number)
            { 
                string[] SurNames =  { "Иванов", "Петров", "Сидоров", "Полянина", "Сидоров" };

                switch (number)
                {
                    case 1: Array.Sort(SurNames);
                        break;
                    case 2: Array.Reverse(SurNames);
                        break;
                }
                foreach (string s in SurNames) Console.WriteLine(s);


            }

        }
    }

    class NumberReader
    {
        Exception[] myException = {
            new FormatException("Мое исключение формата: Введена буква или неправильная цифра!"), 
            new ArgumentException("В метод передан не правильный аргумент сортировки 1 или 2!"),
            new ArgumentOutOfRangeException("Введенное число для сортировки находиться за пределом множества возможных значений!"),
            new NotImplementedException("Данный метод сортировки еще не реализован!"),
            new NotSupportedException("В текущей платформе операция по выбранной сортировке не поддерживаеться!"),
            new TimeoutException("Вы слишком долго выбирали формат сортировки списка!"),
        };
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите значение цифровое 1 или 2 ТОЛЬКО! ниже:");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new FormatException();
            NumberEnteredMetod(number);
        }
        protected virtual void NumberEnteredMetod(int number)
        {
            NumberEnteredEvent.Invoke(number);
        }
    }
}