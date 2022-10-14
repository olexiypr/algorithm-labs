using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laba1
{
    public static class Sort
    {
        private static long sizeInputFile = 16 * 1024 * 1024;
        //"12345678" = 32 bytes;
        private static long countIntInFIle = sizeInputFile / 32;
        private static int servingSize = 1; //розмір порції яка зчитується з двох файлів
        public static void CreateFile() //створення файлу
        {
            var random = new Random();
            using var writer = new StreamWriter("input.txt", false, Encoding.UTF32);
            for (long i = 0; i < countIntInFIle; i++)
            {
                writer.WriteLine(random.Next(10000000, 99999999).ToString());
            }
        }
        public static void StartSort() //початок сортування
        {
            while (servingSize <= countIntInFIle / 2) //сортуємо доки в двох файлах не буде відсортованої послідовності для подальшого злиття
            {
                SplitFile();
                JoinFile();
                servingSize *= 2;
            }
        }

        private static void SplitFile() //записуємо по половині вхідного файлу у вихідні
        {
            using var reader = new StreamReader("input.txt", Encoding.UTF32);
            using (var writer = new StreamWriter("first.txt", false, Encoding.UTF32))
            {
                for (int i = 0; i < countIntInFIle / 2; i++) //записуємо половину вхідного файлу у вихідний
                {
                    string a = reader.ReadLine();
                    var num = int.Parse(a);
                    writer.WriteLine(num);
                }   
            }
            using (var writer = new StreamWriter("second.txt", false, Encoding.UTF32))
            {
                for (int i = 0; i < countIntInFIle / 2; i++)
                {
                    string a = reader.ReadLine();
                    var num = int.Parse(a);
                    writer.WriteLine(num);
                } 
            }
        }
        
        private static void JoinFile() //зливаємо два файли в один
        {
            using var writer = new StreamWriter("input.txt", false, Encoding.UTF32);
            using var reader1 = new StreamReader("first.txt", Encoding.UTF32);
            using var reader2 = new StreamReader("second.txt", Encoding.UTF32);
            var len = countIntInFIle / (2 * servingSize);
            for (var i = 0; i < len; i++)  //ділимо файл на порції та зливаємо їх
            {
                var first = new int[servingSize];
                var second = new int[servingSize];
                string l;
                for (var j = 0; j < servingSize; j++) //зчитаємо по порції данних з першого і другого файлу в масив
                {
                    l = reader1.ReadLine();
                    first[j] = int.Parse(l);
                }
                for (var j = 0; j < servingSize; j++)
                {
                    l = reader2.ReadLine();
                    second[j] = int.Parse(l);
                }
                SortServ(first, second, servingSize, writer);
            }
        }

        private static void SortServ(int[] first, int[] second, int len, StreamWriter writer) //зливає дві порції в файл
        {
            bool flag1 = true, flag2 = true;
            int posA = 0, posB = 0;
            int num1 = first[posA], num2 = second[posB];
            while (true)
            {
                if (posA == len)
                {
                    Write(second, posB, writer);
                    return;
                }
                if (posB == len)
                {
                    Write(first, posA, writer);
                    return;
                }
                if (flag1)
                {
                    num1 = first[posA];
                }
                if (flag2)
                {
                    num2 = second[posB];
                }
                if (num1 > num2)
                {
                    writer.WriteLine(num2);
                    posB++;
                    flag1 = false;
                    flag2 = true;
                }
                else if (num1 < num2)
                {
                    writer.WriteLine(num1);
                    posA++;
                    flag1 = true;
                    flag2 = false;
                }
                else 
                {
                    writer.WriteLine(num1);
                    writer.WriteLine(num2);
                    posA++;
                    posB++;
                    flag1 = true;
                    flag2 = true;
                }
            }
        }
        private static void Write(int [] arr, int pos, StreamWriter writer) //дозаписує частину масиву в файл (якщо другий масив уже записаний)
        {
            for (var i = pos; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
        }
        public static void CheckRes()
        {
            using var reader = new StreamReader("input.txt", Encoding.UTF32);
            for (var i = 0; i < 1000; i++)
            {
                reader.ReadLine();
            }
            for (var i = 0; i < 200; i++)
            {
                Console.WriteLine(int.Parse(reader.ReadLine() ?? string.Empty));
            }
        }
    }
}