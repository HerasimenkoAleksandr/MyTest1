using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    /*  1. Создать коллекцию  из чисел от 1 до 10 и заполнить случайно.Размер коллекции задаётся константой.
  - Создать вторую коллекцию и заполнит случайно от 1 до 10 
  - Сформировать 3 коллекцию где будут числа которые не повторяются в двух коллекциях.
  - Вывести на экран 3 коллекцию
  2,3,4,5
  2,7,4
  Res: 3,5,7*/

    public class Third_collection
    {
        private List<int> list1;
        private List<int> list2;
        private List<int> list3;
        private const int const_list1 = 10;
        private const int const_list2 = 7;
        public Third_collection()
        {
            Random x = new Random();
            list1 = new List<int>();
            for (int i = 0; i < const_list1; i++)
            {
                list1.Add(x.Next(1, 11));
            }

            list2 = new List<int>();
            for (int i = 0; i < const_list2; i++)
            {
                list2.Add(x.Next(1, 11));
            }

        }

        public void Show_list_1_and_2()
        {
            Console.Write("Первая коллекция: ");
            foreach (int i in list1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("Вторая коллекция: ");

            foreach (int i in list2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void Fill_Show_list3()
        {
            list3 = list1.Except(list2).ToList().Union(list2.Except(list1).ToList()).ToList();
            Console.Write("Третья коллекция: ");
            foreach (int i in list3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }


    }


    /*  3. Создать 2 коллекции случайных чисел.
     *  Сформировать коллекцию чисел и их количества из двух предыдущих.Вывести на экран.
  2,3,4,7
  2,5,4
  Res: 
  2 - (2)
  3 - (1)
  4 - (2)
  7 - (1)
  5 - (1)*/
    public class Duplicate_number
    {
        private List<int> list1;
        private List<int> list2;
        private List<int> list3;
        private const int const_list1 = 10;
        private const int const_list2 = 7;
        public Duplicate_number()
        {
            Random x = new Random();
            list1 = new List<int>();
            for (int i = 0; i < const_list1; i++)
            {
                list1.Add(x.Next(1, 11));
            }
            list2 = new List<int>();
            for (int i = 0; i < const_list2; i++)
            {
                list2.Add(x.Next(1, 11));
            }

        }

        public void Show_list_1_and_2()
        {
            Console.Write("Первая коллекция: ");
            foreach (int i in list1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("Вторая коллекция: ");

            foreach (int i in list2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void Fill_Show_list3()
        {
            List<int> list_temp = new List<int>();
            list3 = list1.Concat(list2).ToList();
            list_temp = list3.Distinct().ToList();
            foreach (var i in list_temp)
            {
                int a = 0;
                foreach (var j in list3)
                {
                    if (i == j)
                    {
                        a++;
                    }
                }
                Console.WriteLine($"{i}-({a});");

            }
        }
    }

    /*  2. Проверить на коллекциях их 1000000 элементов.
          Измерить время выполнения с выводом на экран и без.*/

    public class Speed_test
    {
        private int size;
        public Speed_test() { size = 1000000; }
        public void Fill_without_Show()
        {
            
            List<int> list=new List<int>();

            for(int i=0; i <size; i++)
            {
                list.Add(i);
            }
        }
        public void Fill_and_Show()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
               
            }
            foreach (var i in list)
            {
                if (i % 15 == 0) 
                { Console.WriteLine(); 
                }
                Console.Write(i + " ");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Third_collection third_Collection = new Third_collection();
            third_Collection.Show_list_1_and_2();
            third_Collection.Fill_Show_list3();
//-------------------------------------------------------------------------------------------------------
            Console.WriteLine("\nЗадание 3");
            Duplicate_number duplicate_Number = new Duplicate_number();
            duplicate_Number.Show_list_1_and_2();
            duplicate_Number.Fill_Show_list3();
//-------------------------------------------------------------------------------------------------------
            Console.WriteLine("\nЗадание 2\nНажмите любую клавишу - проверим скорость заполнения колекции" +
                "на 1000000 элементов без вывода на экран");
            Console.ReadKey();
            Console.Clear();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Speed_test speed_Test = new Speed_test();
            speed_Test.Fill_without_Show();
            sw.Stop();
            Console.WriteLine($"\nскорость: {sw.Elapsed}");
//-------------------------------------------------------------------------------------------------------
            Console.WriteLine("\nНажмите любую клавишу - проверим скорость заполнения колекции" +
               "на 1000000 элементов с выводом на экран");
            Console.ReadKey();
            Console.Clear();
            sw.Start();
            speed_Test.Fill_and_Show();
            sw.Stop();
            Console.WriteLine($"\n\nскорость: {sw.Elapsed}");
        }
    }
}
